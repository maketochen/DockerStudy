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

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return appDbContext.TouristRoutePictures.Where(x => x.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return  appDbContext.TouristRoutes.FirstOrDefault(x => x.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return appDbContext.TouristRoutes;
        }

        public async Task<bool> TouristRouteExists(Guid touristRouteId)
        {
            return appDbContext.TouristRoutes.Any(x => x.Id == touristRouteId);
        }
    }
}
