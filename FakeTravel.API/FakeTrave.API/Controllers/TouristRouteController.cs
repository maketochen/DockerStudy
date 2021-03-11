using AutoMapper;
using FakeTrave.API.Dtos;
using FakeTrave.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRouteController : ControllerBase
    {
        private ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        public TouristRouteController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var touristRouteFromRepo = touristRouteRepository.GetTouristRoutes();
            if (touristRouteFromRepo == null)
            {
                return NotFound("目前暂停所有旅游路线");
            }
            var touristRouteDto = mapper.Map<IEnumerable<TouristRouteDto>>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }

        //[HttpGet("{touristRouteId:*}")] 类型限定为*
        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = touristRouteRepository.GetTouristRoute(touristRouteId);
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

    }
}
