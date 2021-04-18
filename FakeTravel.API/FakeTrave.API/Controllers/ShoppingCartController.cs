using AutoMapper;
using FakeTrave.API.Dtos;
using FakeTrave.API.Helper;
using FakeTrave.API.Models;
using FakeTrave.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FakeTrave.API.Controllers
{
    [ApiController]
    [Route("api/shoppingCart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;

        public ShoppingCartController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> GetShoppingCart()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //使用userid获取购物车
            var shoppingCart = await touristRouteRepository.GetShoppingCartByUserId(userId);

            return Ok(mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        [HttpPost("items")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddShoppingCartItem([FromBody] AddShoppingCartItemDto shoppingCartItemDto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var shoppingCart = await touristRouteRepository.GetShoppingCartByUserId(userId);

            var touristRoute = await touristRouteRepository.GetTouristRouteAsync(shoppingCartItemDto.TouristRouteId);

            if (touristRoute == null)
            {
                return NotFound("旅游路线不存在");
            }

            var lineItem = new LineItem()
            {
                TouristRouteId = shoppingCartItemDto.TouristRouteId,
                ShoppingCartId = shoppingCart.Id,
                OriginalPrice = touristRoute.OriginalPrice,
                DiscountPresent = touristRoute.DiscountPresent
            };
            await touristRouteRepository.ShoppingCartItem(lineItem);
            await touristRouteRepository.SaveAsync();

            return Ok(mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        [HttpDelete("items/{itemId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteShoppingCartItem([FromRoute] int ItemId)
        {
            var lineItem = await touristRouteRepository.GetShoppingCartItemByItemId(ItemId);
            if (lineItem == null)
            {
                return NotFound("购物车商品未找到");
            }

            touristRouteRepository.DeleteShoppingCartItem(lineItem);
            await touristRouteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("items/({ItemDtos})")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> RemoveShoppingCartItems(
            [ModelBinder(BinderType=typeof(ArrayModelBinder))] 
            [FromRoute] IEnumerable<int> ItemDtos)
        {
            var lineItems = await touristRouteRepository.GetShoppingCartsByIdListAsync(ItemDtos);

            touristRouteRepository.DeleteShoppingCartItems(lineItems);
            await touristRouteRepository.SaveAsync();

            return NoContent();
        }

    }
}
