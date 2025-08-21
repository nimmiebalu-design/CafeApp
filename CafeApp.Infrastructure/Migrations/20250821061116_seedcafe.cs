using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedcafe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cafes",
                columns: new[] { "id", "description", "location", "logo", "name" },
                values: new object[,]
                {
                    { new Guid("905dd236-c348-4d3b-ac3e-923afed6e3de"), "A small cafe specializing in espresso drinks.", "Uptown", null, "Cafe Espresso" },
                    { new Guid("aee86791-d668-408d-bfd6-43543cf24a73"), "A cozy cafe with a variety of coffee and snacks.", "Downtown", null, "Cafe Latte" },
                    { new Guid("fae99b40-7623-42c2-b6f3-d01ca8c7d784"), "A cafe known for its American-style coffee.", "Uptown", null, "Cafe Americano" },
                    { new Guid("ff40f939-52bb-4511-aa3b-07b519403a08"), "A cozy cafe with a variety of coffee and snacks.", "Downtown", null, "Cafe Mocha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cafes",
                keyColumn: "id",
                keyValue: new Guid("905dd236-c348-4d3b-ac3e-923afed6e3de"));

            migrationBuilder.DeleteData(
                table: "Cafes",
                keyColumn: "id",
                keyValue: new Guid("aee86791-d668-408d-bfd6-43543cf24a73"));

            migrationBuilder.DeleteData(
                table: "Cafes",
                keyColumn: "id",
                keyValue: new Guid("fae99b40-7623-42c2-b6f3-d01ca8c7d784"));

            migrationBuilder.DeleteData(
                table: "Cafes",
                keyColumn: "id",
                keyValue: new Guid("ff40f939-52bb-4511-aa3b-07b519403a08"));
        }
    }
}
