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

        public TouristRoute GetTouristRoute(Guid TouristRouteId)
        {
            return routes.FirstOrDefault(x => x.Id == TouristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return routes;
        }
    }
}
