using FakeTrave.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//数据验证
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Dtos
{
    [TouristRouteTitleMustBeDifferentFromDescriptionAttribute]
    public class TouristRouteForCreationDto : TouristRouteForManipulationDto
    {

    }
}
