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

        public TouristRouteController(ITouristRouteRepository touristRouteRepository)
        {
            this.touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
        }

        public IActionResult GetTouristRoutes()
        {
            var routes = touristRouteRepository.GetTouristRoutes();
            return Ok(routes);
        }
    }
}
