using FakeTrave.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Services
{
    public interface ITouristRouteRepository
    {
        /// <summary>
        /// 返回旅游路线
        /// </summary>
        /// <returns></returns>
        IEnumerable<TouristRoute> GetTouristRoutes();

        /// <summary>
        /// 返回旅游路线
        /// </summary>
        /// <returns></returns>
        TouristRoute GetTouristRoute(Guid touristRouteId);

        Task<bool> TouristRouteExists(Guid touristRouteId);

        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);

    }
}
