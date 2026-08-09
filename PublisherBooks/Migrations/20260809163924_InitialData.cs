using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublisherBooks.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "City", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7"), "Melbourne", "Australia", "Aurora Books" },
                    { new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18"), "Manchester", "United Kingdom", "Northwind Press" },
                    { new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885"), "Toronto", "Canada", "Silverleaf Publishing" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Genre", "PageCount", "PublisherId", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { new Guid("1e0ef065-7153-4555-b23d-242e27bc4cbf"), "Poetry", 190, new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885"), 2023, "Concrete and Rain" },
                    { new Guid("2343c3e6-a2db-4b5c-87af-e7e0605d816a"), "Literary fiction", 312, new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18"), 2018, "The Quiet Harbour" },
                    { new Guid("66fdae8f-eb22-487a-8def-a138928f205b"), "Mystery", 264, new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885"), 2019, "Winter Lantern" },
                    { new Guid("800dfb90-d562-4595-9878-6ff361456cd0"), "Historical fiction", 526, new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7"), 2020, "The Cartographer's Debt" },
                    { new Guid("b0d5912d-d356-4dd9-b783-a95625c8a528"), "Science", 358, new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7"), 2022, "Southern Reef" },
                    { new Guid("f9d3ab49-d925-4e8c-b380-7c60b444b94a"), "History", 448, new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18"), 2021, "Patterns of the North" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1e0ef065-7153-4555-b23d-242e27bc4cbf"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("2343c3e6-a2db-4b5c-87af-e7e0605d816a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("66fdae8f-eb22-487a-8def-a138928f205b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("800dfb90-d562-4595-9878-6ff361456cd0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b0d5912d-d356-4dd9-b783-a95625c8a528"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("f9d3ab49-d925-4e8c-b380-7c60b444b94a"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("2dddc208-8925-41c4-80ec-bb58ee833dc7"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("8c76b8a8-f748-4eed-b13b-5ce2ba50ce18"));

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: new Guid("c67499e0-0041-4ee3-98b1-b2fdf6834885"));
        }
    }
}
