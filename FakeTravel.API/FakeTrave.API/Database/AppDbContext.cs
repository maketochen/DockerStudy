using FakeTrave.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FakeTrave.API.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }

        public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

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
            // 初始化用户与角色的种子数据
            //1.更新用户与角色的外键
            modelBuilder.Entity<ApplicationUser>(x =>x.HasMany(y => y.UserRoles)
               .WithOne()
               .HasForeignKey(ur => ur.UserId)
               .IsRequired()
            );
        //2.添加管理员角色
        var adminRoleId = "7CBBEB8B-910B-4719-8614-17E4A8D12488";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                });
            //3.添加用户
            var adminUserId = "2E993E1B-C833-4529-9640-E85150AC9434";
            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = adminUserId,
                UserName = "admin@qq.com",
                NormalizedUserName = "admin@qq.com".ToUpper(),
                Email = "admin@qq.com",
                NormalizedEmail = "admin@qq.com".ToUpper(),
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
            };
            var ph = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "Fake123$");
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            //4.给用户加入管理员角色
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
