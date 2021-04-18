using FakeTrave.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Services
{
    public class MockTouristRouteRepository : ITouristRouteRepository
    {
        private List<TouristRoute> routes;

        public MockTouristRouteRepository()
        {
            if (routes == null)
            {
                MockTouristRoutes();
            }
        }

        private void MockTouristRoutes()
        {
            routes =  new List<TouristRoute>
           {
               new TouristRoute
               {
                Id =Guid.NewGuid(),
                Title ="深圳",
                Description="深圳真不错",
                OriginalPrice=1999,
                DiscountPresent =999,
                Features="<p>来了深圳就是打工人</p>",
                Fees="<p>深圳赚钱深圳花</p>",
                Notes="<p>注意安全</p>"
               },
               new TouristRoute
               {
                Id =Guid.NewGuid(),
                Title ="上海",
                Description="上海真不错",
                OriginalPrice=1999,
                DiscountPresent =999,
                Features="<p>来了上海就是上海人</p>",
                Fees="<p>上海赚钱上海花</p>",
                Notes="<p>注意安全</p>"
               }
           };
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return routes.FirstOrDefault(x => x.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return routes;
        }


        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string operatorType, int? ratingValue)
        {
            throw new NotImplementedException();
        }

        public void AddTouristRoute(TouristRoute touristRoute)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture)
        {
            throw new NotImplementedException();
        }

        public void DeleteTouristRoute(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTouristRoute(TouristRoute touristRoute)
        {
            throw new NotImplementedException();
        }

        public void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TouristRoute> GetTouristRouteByIDList(IEnumerable<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword, string operatorType, int? ratingValue)
        {
            throw new NotImplementedException();
        }

        public Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TouristRouteExistsAsync(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TouristRoutePicture>> GetPicturesByTouristRouteIdAsync(Guid touristRouteId)
        {
            throw new NotImplementedException();
        }

        public Task<TouristRoutePicture> GetPictureAsync(int pictureId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TouristRoute>> GetTouristRouteByIDListAsync(IEnumerable<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetShoppingCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task CraeteShoppingCartAsync(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }

        public Task ShoppingCartItem(LineItem lineItem)
        {
            throw new NotImplementedException();
        }

        public Task<LineItem> GetShoppingCartItemByItemId(int lineItemId)
        {
            throw new NotImplementedException();
        }

        public void DeleteShoppingCartItem(LineItem lineItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> Ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems)
        {
            throw new NotImplementedException();
        }
    }
}
