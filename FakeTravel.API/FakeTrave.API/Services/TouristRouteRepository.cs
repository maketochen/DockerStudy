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


        public async Task CraeteShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await appDbContext.ShoppingCarts.AddAsync(shoppingCart);
        }

        public void DeleteShoppingCartItem(LineItem lineItem)
        {
            appDbContext.LineItems.Remove(lineItem);
        }

        public void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems)
        {
            appDbContext.LineItems.RemoveRange(lineItems);
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

        public async Task<TouristRoutePicture> GetPictureAsync(int pictureId)
        {
            return await appDbContext.TouristRoutePictures.Where(x => x.Id == pictureId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TouristRoutePicture>> GetPicturesByTouristRouteIdAsync(Guid touristRouteId)
        {
            return await appDbContext.TouristRoutePictures.Where(x => x.TouristRouteId == touristRouteId).ToListAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserId(string userId)
        {
            return await appDbContext.ShoppingCarts
                .Include(x => x.User)
                .Include(x => x.ShoppingCartItems)
                .ThenInclude(li => li.TouristRoute)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
            
        }

        public async Task<LineItem> GetShoppingCartItemByItemId(int lineItemId)
        {
            return await appDbContext.LineItems.Where(x => x.Id == lineItemId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> Ids)
        {
           return await appDbContext.LineItems.Where(li => Ids.Contains(li.Id)).ToListAsync();
        }

        public async Task<TouristRoute> GetTouristRouteAsync(Guid touristRouteId)
        {
            return await appDbContext.TouristRoutes.Include(x => x.TouristRoutePictures).FirstOrDefaultAsync(x => x.Id == touristRouteId);
        }

        public async Task<IEnumerable<TouristRoute>> GetTouristRouteByIDListAsync(IEnumerable<Guid> IDs)
        {
            return await appDbContext.TouristRoutes.Where(t => IDs.Contains(t.Id)).ToListAsync();
        }

        public async Task<IEnumerable<TouristRoute>> GetTouristRoutesAsync(string keyword,
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

            return await result.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }

        public async Task ShoppingCartItem(LineItem lineItem)
        {
            await appDbContext.LineItems.AddAsync(lineItem);
        }

        public async Task<bool> TouristRouteExistsAsync(Guid touristRouteId)
        {
            return await appDbContext.TouristRoutes.AnyAsync(x => x.Id == touristRouteId);
        }


    }
}
