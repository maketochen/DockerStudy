﻿using AutoMapper;
using FakeTrave.API.Dtos;
using FakeTrave.API.Helper;
using FakeTrave.API.Models;
using FakeTrave.API.ResourceParameters;
using FakeTrave.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeTrave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRouteController : ControllerBase
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        public TouristRouteController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetTouristRoutesAsync(
            [FromQuery] TouristRouteResourceParameters parameters
            //[FromQuery] string keyword,
            //string rating // 小于lessThan 大于largeThan 等于equalTo
            )
        {


            var touristRouteFromRepo = await touristRouteRepository.GetTouristRoutesAsync(parameters.keyword, parameters.RatingOperator, parameters.RatingValue);
            if (touristRouteFromRepo == null)
            {
                return NotFound("目前暂停所有旅游路线");
            }
            var touristRouteDto = mapper.Map<IEnumerable<TouristRouteDto>>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }


        //[HttpGet("{touristRouteId:*}")] 类型限定为*
        [HttpGet("{touristRouteId}", Name = "GetTouristRouteById")]
        [HttpHead]
        public async Task<IActionResult> GetTouristRouteByIdAsync(Guid touristRouteId)
        {
            var touristRouteFromRepo = await touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"不存在旅游路线{touristRouteId}");
            }
            #region Obsolete 
            //var touristRouteDto = new TouristRouteDto()
            //{
            //    Id = touristRouteFromRepo.Id,
            //    Title = touristRouteFromRepo.Title,
            //    Description = touristRouteFromRepo.Description,
            //    Price = touristRouteFromRepo.OriginalPrice *
            //    Convert.ToDecimal(touristRouteFromRepo.DiscountPresent ?? 1),
            //    CreateTime = touristRouteFromRepo.CreateTime,
            //    UpdateTime = touristRouteFromRepo.UpdateTime,
            //    Features = touristRouteFromRepo.Features,
            //    Fees = touristRouteFromRepo.Fees,
            //    Notes = touristRouteFromRepo.Notes,
            //    Rating = touristRouteFromRepo.Rating,
            //    TravelDays = touristRouteFromRepo.TravelDays.ToString(),
            //    TripType = touristRouteFromRepo.TripType.ToString(),
            //    DepartureCity = touristRouteFromRepo.DepartureCity.ToString()
            //};
            #endregion
            var touristRouteDto = mapper.Map<TouristRouteDto>(touristRouteFromRepo);

            return Ok(touristRouteDto);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
       // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateTouristRouteAsync([FromBody] TouristRouteForCreationDto creationDto)
        {
            var touristRouteModel = mapper.Map<TouristRoute>(creationDto);
            touristRouteRepository.AddTouristRoute(touristRouteModel);
            await touristRouteRepository.SaveAsync();
            var touristRouteToReture = mapper.Map<TouristRouteDto>(touristRouteModel);
            return CreatedAtRoute("GetTouristRouteById", new { touristRouteId = touristRouteToReture.Id }, touristRouteToReture);
        }

        [HttpPut("{touristRouteId}")]
        public async Task<IActionResult> UpdateTouristRouteAsync(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRouteForUpdateDto updateDto)
        {
            if (!(await touristRouteRepository.TouristRouteExistsAsync(touristRouteId)))
            {
                return NotFound("旅游路线找不到");
            }
            //映射dto  更新dto 映射model 实体模型追踪已更新 直接SaveChanges
            var touristRouteFromRepo = await touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            mapper.Map(updateDto, touristRouteFromRepo);

            await touristRouteRepository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{touristRouteId}")]
        public async Task<IActionResult> PartialLyUpdateTouristRouteAsync([FromRoute] Guid touristRouteId, [FromBody] JsonPatchDocument<TouristRouteForUpdateDto> patchDocument)
        {
            if (!(await touristRouteRepository.TouristRouteExistsAsync(touristRouteId)))
            {
                return NotFound("旅游路线找不到");
            }

            var touristRouteFromRepo = await touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            var toursitRouteToPatch = mapper.Map<TouristRouteForUpdateDto>(touristRouteFromRepo);
            patchDocument.ApplyTo(toursitRouteToPatch, ModelState);
            if (!TryValidateModel(toursitRouteToPatch))
            {
                return ValidationProblem(ModelState);
            }
            mapper.Map(toursitRouteToPatch, touristRouteFromRepo);
            await touristRouteRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{touristRouteId}")]
        public async Task<IActionResult> DeleteTouristRouteAsync([FromRoute] Guid touristRouteId)
        {
            if (!(await touristRouteRepository.TouristRouteExistsAsync(touristRouteId)))
            {
                return NotFound("旅游路线找不到");
            }
            var touristRoute = await touristRouteRepository.GetTouristRouteAsync(touristRouteId);
            touristRouteRepository.DeleteTouristRoute(touristRoute);
            await touristRouteRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("({touristIDs})")]
        public async Task<IActionResult> DeleteByIDsAsync(
        [FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))]
         IEnumerable<Guid> touristIDs)
        {
            if (touristIDs == null)
            {
                return BadRequest();
            }
            var touristRoutesFromRepo = await touristRouteRepository.GetTouristRouteByIDListAsync(touristIDs);
            touristRouteRepository.DeleteTouristRoutes(touristRoutesFromRepo);
            await touristRouteRepository.SaveAsync();
            return NoContent();

        }
    }
}
