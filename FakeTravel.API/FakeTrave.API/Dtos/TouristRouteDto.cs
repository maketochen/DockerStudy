using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Dtos
{
    public class TouristRouteDto
    {
        /// <summary>
        /// 路线Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 路线名字
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 路线简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 价格 = 原价 *折扣
        /// </summary>
        public decimal Price { get; set; }

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

        public string Features { get; set; }
        /// <summary>
        /// 路线费用说明
        /// </summary>

        public string Fees { get; set; }
        /// <summary>
        /// 路线提示内容
        /// </summary>

        public string Notes { get; set; }
        /// <summary>
        /// 路线评分
        /// </summary>
        public double? Rating { get; set; }
        /// <summary>
        /// 路线时长
        /// </summary>
        public string TravelDays { get; set; }
        /// <summary>
        /// 旅游类型
        /// </summary>
        public string TripType { get; set; }
        /// <summary>
        /// 出发地
        /// </summary>
        public string DepartureCity { get; set; }
    }
}
