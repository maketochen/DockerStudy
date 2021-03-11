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
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private ITouristRouteRepository touristRouteRepository;
        private IMapper mapper;

        public TouristRoutePicturesController(IMapper mapper, ITouristRouteRepository touristRouteRepository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
        }

        public async Task<IActionResult> GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (!(await touristRouteRepository.TouristRouteExists(touristRouteId)))
            {
                return NotFound($"{touristRouteId}旅游路线不存在");
            }
            var picturesFormRepo = touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);

            if (picturesFormRepo == null)
            {
                return NotFound("照片不存在");
            }
            return Ok(mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFormRepo));

        }
    }
}
