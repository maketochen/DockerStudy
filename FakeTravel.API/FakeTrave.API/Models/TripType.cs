using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Models
{
    /// <summary>
    /// 旅游类型
    /// </summary>
    public enum TripType
    {
        /// <summary>
        ///  酒店加景点
        /// </summary>
        HotelAndAttractions,
        /// <summary>
        /// 跟团游
        /// </summary>
        Group,
        /// <summary>
        /// 私家团
        /// </summary>
        PrivateGroup,
        /// <summary>
        /// 自由行
        /// </summary>
        BackPackTour,
        /// <summary>
        /// 半自助游
        /// </summary>
        SemiBackPackTour
    }
}
