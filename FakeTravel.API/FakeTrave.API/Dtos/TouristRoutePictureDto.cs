using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Dtos
{
    public class TouristRoutePictureDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 照片路径
        /// </summary>
         
        public string Url { get; set; }
        /// <summary>
        /// 旅游路线Id
        /// </summary>
        public Guid TouristRouteId { get; set; }
         
    }
}
