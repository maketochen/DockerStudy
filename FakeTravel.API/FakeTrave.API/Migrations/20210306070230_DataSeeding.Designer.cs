﻿// <auto-generated />
using System;
using FakeTrave.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeTrave.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210306070230_DataSeeding")]
    partial class DataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeTrave.API.Models.TouristRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1280)")
                        .HasMaxLength(1280);

                    b.Property<double?>("DiscountPresent")
                        .HasColumnType("float");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fees")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TouristRoutes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e359456-59d3-4b12-a74d-95d62dbbad0d"),
                            CreateTime = new DateTime(2021, 3, 6, 7, 2, 30, 400, DateTimeKind.Utc).AddTicks(8190),
                            Description = "Remarks",
                            OriginalPrice = 0m,
                            Title = "TestTitle"
                        });
                });

            modelBuilder.Entity("FakeTrave.API.Models.TouristRoutePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("TouristRouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("TouristRouteId");

                    b.ToTable("TouristRoutePictures");
                });

            modelBuilder.Entity("FakeTrave.API.Models.TouristRoutePicture", b =>
                {
                    b.HasOne("FakeTrave.API.Models.TouristRoute", "TouristRoute")
                        .WithMany("touristRoutePictures")
                        .HasForeignKey("TouristRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
