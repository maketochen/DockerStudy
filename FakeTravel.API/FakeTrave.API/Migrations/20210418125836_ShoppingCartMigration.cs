using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeTrave.API.Migrations
{
    public partial class ShoppingCartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("44c75650-13e1-40a1-ab31-6d74d3e8f00a"));

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristRouteId = table.Column<Guid>(nullable: false),
                    ShoppingCartId = table.Column<Guid>(nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DiscountPresent = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineItems_TouristRoutes_TouristRouteId",
                        column: x => x.TouristRouteId,
                        principalTable: "TouristRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7CBBEB8B-910B-4719-8614-17E4A8D12488",
                column: "ConcurrencyStamp",
                value: "e905cdfa-0952-44b7-b4cc-8b4e58f0ef9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E993E1B-C833-4529-9640-E85150AC9434",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83bfdb1a-7e6f-4c2e-ad50-bb95658f9a8f", "AQAAAAEAACcQAAAAEKvk2LguhanvVesfDlCubWKhiAOzyGdjC79WLsPJni0UjbouOLZIgzzLPgAp8Ue3pQ==", "eca5cdc2-8ad0-4b89-9859-fe18e4dedd3c" });

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureCity", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "Title", "TravelDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("9646d578-d842-46b9-8383-0f139f0dd179"), new DateTime(2021, 4, 18, 12, 58, 35, 655, DateTimeKind.Utc).AddTicks(2041), 0, null, "Remarks", null, null, null, null, 0m, 3.0, "TestTitle", 8, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ShoppingCartId",
                table: "LineItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_TouristRouteId",
                table: "LineItems",
                column: "TouristRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("9646d578-d842-46b9-8383-0f139f0dd179"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7CBBEB8B-910B-4719-8614-17E4A8D12488",
                column: "ConcurrencyStamp",
                value: "b4fdb2e8-8ab4-4f2a-8995-e4521460bb5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2E993E1B-C833-4529-9640-E85150AC9434",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69bb2170-fda0-43fa-9fcd-18192d944081", "AQAAAAEAACcQAAAAEP6GuFZ4obN7btsvQ4rRkUGose4yRjDd0a3CPJazsuh8toUr2xd9jN8OTXLtnos/BQ==", "c27432a5-06c8-4995-a998-7ddb1e43819c" });

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureCity", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "Title", "TravelDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("44c75650-13e1-40a1-ab31-6d74d3e8f00a"), new DateTime(2021, 4, 17, 18, 15, 42, 281, DateTimeKind.Utc).AddTicks(1745), 0, null, "Remarks", null, null, null, null, 0m, 3.0, "TestTitle", 8, 3, null });
        }
    }
}
