using FakeTrave.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FakeTrave.API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }

        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
            {
                Id = Guid.NewGuid(),
                Title = "TestTitle",
                Description = "Remarks",
                OriginalPrice = 0,
                CreateTime = DateTime.UtcNow,
                Rating = 3,
                TravelDays = TravelDays.EightPlus,
                TripType = TripType.BackPackTour,
                DepartureCity = DepartureCity.Beijing
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
