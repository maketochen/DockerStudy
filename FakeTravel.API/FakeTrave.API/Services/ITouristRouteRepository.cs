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
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string operatorType, int? ratingValue);

        /// <summary>
        /// 返回旅游路线
        /// </summary>
        /// <returns></returns>
        TouristRoute GetTouristRoute(Guid touristRouteId);
        /// <summary>
        /// 查询指定旅游路线Id是否存在
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        bool TouristRouteExists(Guid touristRouteId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);

        void AddTouristRoute(TouristRoute touristRoute);

        void AddTouristRoutePicture(Guid touristRouteId,TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
        bool Save();
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        IEnumerable<TouristRoute> GetTouristRouteByIDList(IEnumerable<Guid> IDs);
    }
}
