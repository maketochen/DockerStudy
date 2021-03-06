using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeTrave.API.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("6e359456-59d3-4b12-a74d-95d62dbbad0d"), new DateTime(2021, 3, 6, 7, 2, 30, 400, DateTimeKind.Utc).AddTicks(8190), null, "Remarks", null, null, null, null, 0m, "TestTitle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("6e359456-59d3-4b12-a74d-95d62dbbad0d"));
        }
    }
}
