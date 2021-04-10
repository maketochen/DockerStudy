﻿using AutoMapper;
using FakeTrave.API.Dtos;
using FakeTrave.API.Models;
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
        [HttpGet]
        public IActionResult GetPictureListForTouristRouteAsync(Guid touristRouteId)
        {
            if (!(touristRouteRepository.TouristRouteExists(touristRouteId)))
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
        [HttpGet("{pictureId}", Name = "GetPicture")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            if (!(touristRouteRepository.TouristRouteExists(touristRouteId)))
            {
                return NotFound($"{touristRouteId}旅游路线不存在");
            }

            var pictureFromRepo = touristRouteRepository.GetPicture(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("相片不存在");
            }
            return Ok(mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
        }

        public IActionResult CreateTouristRoutePicture(
            [FromRoute] Guid touristRouteId,
            [FromBody] TouristRoutePictureForCreatetionDto createtionDto)
        {
            if (!(touristRouteRepository.TouristRouteExists(touristRouteId)))
            {
                return NotFound($"{touristRouteId}旅游路线不存在");
            }
            var pictureModel = mapper.Map<TouristRoutePicture>(createtionDto);
            touristRouteRepository.AddTouristRoutePicture(touristRouteId, pictureModel);
            touristRouteRepository.Save();
            var pictureToReturn = mapper.Map<TouristRoutePictureDto>(pictureModel);
            return CreatedAtRoute("GetPicture", new
            {
                touristRouteId = pictureModel.TouristRouteId,
                pictureId = pictureModel.Id
            }, pictureToReturn);

        }
    }
}
