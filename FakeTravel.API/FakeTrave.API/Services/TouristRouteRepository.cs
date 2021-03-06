using FakeTrave.API.Database;
using FakeTrave.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTrave.API.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext appDbContext;

        public TouristRouteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public TouristRoute GetTouristRoute(Guid TouristRouteId)
        {
            return  appDbContext.TouristRoutes.FirstOrDefault(x => x.Id == TouristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return appDbContext.TouristRoutes;
        }
    }
}
