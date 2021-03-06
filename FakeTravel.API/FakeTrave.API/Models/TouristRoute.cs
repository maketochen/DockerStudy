using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Models
{
    /// <summary>
    /// 旅游路线
    /// </summary>
    public class TouristRoute
    {
        /// <summary>
        /// 路线Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 路线名字
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        /// <summary>
        /// 路线简介
        /// </summary>
        [MaxLength(1280)]
        public string Description { get; set; }
        /// <summary>
        /// 路线原价
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// 路线折扣价
        /// </summary>
        [Range(0.0, 1.0)]
        public double? DiscountPresent { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime? DepartureTime { get; set; }
        /// <summary>
        /// 路线卖点介绍
        /// </summary>
        [MaxLength]
        public string Features { get; set; }
        /// <summary>
        /// 路线费用说明
        /// </summary>
        [MaxLength]
        public string Fees { get; set; }
        /// <summary>
        /// 路线提示内容
        /// </summary>
        [MaxLength]
        public string Notes { get; set; }
        /// <summary>
        /// 旅游路线
        /// </summary>
        public ICollection<TouristRoutePicture> touristRoutePictures { get; set; }
        /// <summary>
        /// 路线评分
        /// </summary>
        public double? Rating { get; set; }
        /// <summary>
        /// 路线时长
        /// </summary>
        public TravelDays? TravelDays { get; set; }
        /// <summary>
        /// 旅游类型
        /// </summary>
        public TripType? TripType { get; set; }

    }
}
