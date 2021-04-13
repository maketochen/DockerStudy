using FakeTrave.API.Database;
using FakeTrave.API.Models;
using Microsoft.EntityFrameworkCore;
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

        public void AddTouristRoute(TouristRoute touristRoute)
        {
            if (touristRoute == null)
            {
                throw new ArgumentNullException(nameof(touristRoute));
            }
            appDbContext.TouristRoutes.Add(touristRoute);
        }

        public void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture)
        {
            if (touristRouteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(touristRouteId));
            }
            if (touristRoutePicture == null)
            {
                throw new ArgumentNullException(nameof(touristRoutePicture));
            }
            touristRoutePicture.TouristRouteId = touristRouteId;
            appDbContext.TouristRoutePictures.Add(touristRoutePicture);
        }

        public void DeleteTouristRoute(TouristRoute touristRoute)
        {
            appDbContext.TouristRoutes.Remove(touristRoute);
        }

        public void DeleteTouristRoutePicture(TouristRoutePicture touristRoutePicture)
        {
            appDbContext.TouristRoutePictures.Remove(touristRoutePicture);
        }

        public void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes)
        {
            appDbContext.TouristRoutes.RemoveRange(touristRoutes);
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return appDbContext.TouristRoutePictures.Where(x => x.Id == pictureId).FirstOrDefault();
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return appDbContext.TouristRoutePictures.Where(x => x.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return appDbContext.TouristRoutes.Include(x => x.TouristRoutePictures).FirstOrDefault(x => x.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRouteByIDList(IEnumerable<Guid> IDs)
        {
            return appDbContext.TouristRoutes.Where(t => IDs.Contains(t.Id)).ToList();
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword,
            string operatorType,
            int? ratingValue)
        {
            IQueryable<TouristRoute> result = appDbContext.TouristRoutes.Include(x => x.TouristRoutePictures);
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(x => x.Title.Contains(keyword));
            }
            if (ratingValue >= 0)
            {
                result = operatorType switch
                {
                    "largerThan" => result.Where(t => t.Rating >= ratingValue),
                    "lessThan" => result.Where(t => t.Rating <= ratingValue),
                    _ => result.Where(t => t.Rating == ratingValue),
                };
            }

            return result.ToList();
        }

        public bool Save()
        {
            return appDbContext.SaveChanges() > 0;
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            return appDbContext.TouristRoutes.Any(x => x.Id == touristRouteId);
        }


    }
}
