using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Models
{
    /// <summary>
    /// 旅游路线照片
    /// </summary>
    public class TouristRoutePicture
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 照片路径
        /// </summary>
        [MaxLength(128)]
        public string Url { get; set; }
        /// <summary>
        /// 旅游路线Id
        /// </summary>
        [ForeignKey("TouristRouteId")]
        public Guid TouristRouteId { get; set; }
        /// <summary>
        /// 旅游路线
        /// </summary>
        public TouristRoute TouristRoute { get; set; }

    }
}
