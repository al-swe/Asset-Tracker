using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniProjectCW2122.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Cost", "Currency", "LocalCost", "Model", "Office", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "Dell", 199m, "SEK", 1999m, "XPS 13", "Sweden", new DateTime(2021, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 2, "Apple", 999m, "USD", 999m, "iPhone 12", "USA", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobiles" },
                    { 3, "HP", 1500m, "EUR", 1500m, "Spectre x360", "UK", new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 4, "Samsung", 850m, "GBP", 850m, "Galaxy S21", "UK", new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobiles" },
                    { 5, "Apple", 2500m, "CAD", 2500m, "MacBook Pro", "Sweden", new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 6, "OnePlus", 650m, "INR", 48000m, "9 Pro", "USA", new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobiles" },
                    { 7, "Lenovo", 2200m, "AUD", 2200m, "ThinkPad X1", "UK", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer" },
                    { 8, "Google", 700m, "JPY", 77000m, "Pixel 5", "Sweden", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobiles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
