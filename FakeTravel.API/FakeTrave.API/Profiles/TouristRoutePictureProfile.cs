using FakeTrave.API.Dtos;
using FakeTrave.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FakeTrave.API.Profiles
{
    public class TouristRoutePictureProfile : Profile
    {
        public TouristRoutePictureProfile()
        {
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();

            CreateMap<TouristRoutePictureForCreatetionDto, TouristRoutePicture>();
        }
    }
}
