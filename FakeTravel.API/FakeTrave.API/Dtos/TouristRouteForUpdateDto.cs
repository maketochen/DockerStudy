using FakeTrave.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Dtos
{
    [TouristRouteTitleMustBeDifferentFromDescriptionAttribute]
    public class TouristRouteForUpdateDto : TouristRouteForManipulationDto
    {
        /// <summary>
        /// 路线简介
        /// </summary>
        [Required(ErrorMessage ="更新必备")]
        [MaxLength(1280)]
        public override string Description { get; set; }
    }
}
