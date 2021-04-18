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
        Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword, string operatorType, int? ratingValue);

        /// <summary>
        /// 返回旅游路线
        /// </summary>
        /// <returns></returns>
        Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId);
        /// <summary>
        /// 查询指定旅游路线Id是否存在
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        Task<bool> TouristRouteExistsAsync(Guid touristRouteId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="touristRouteId"></param>
        /// <returns></returns>
        Task<IEnumerable<TouristRoutePicture>> GetPicturesByTouristRouteIdAsync(Guid touristRouteId);

        Task<TouristRoutePicture> GetPictureAsync(int pictureId);

        void AddTouristRoute(TouristRoute touristRoute);

        void AddTouristRoutePicture(Guid touristRouteId,TouristRoutePicture touristRoutePicture);
        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
        Task<bool> SaveAsync();
        void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture);
        Task<IEnumerable<TouristRoute>> GetTouristRouteByIDListAsync(IEnumerable<Guid> IDs);

        Task<ShoppingCart> GetShoppingCartByUserId(string userId);

        Task ShoppingCartItem(LineItem lineItem);

        Task<LineItem> GetShoppingCartItemByItemId(int lineItemId);

        Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> Ids);

        void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems);

        void DeleteShoppingCartItem(LineItem lineItem);

        Task CraeteShoppingCartAsync(ShoppingCart shoppingCart);
    }
}
