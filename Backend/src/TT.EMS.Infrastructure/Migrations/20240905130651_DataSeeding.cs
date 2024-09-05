using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TT.EMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Sex" },
                values: new object[,]
                {
                    { new Guid("115bf8ee-142c-42ce-8fc9-83bc47c1ae6c"), 27, "Jane", "Doe", "Male" },
                    { new Guid("2d88d221-75a3-416a-8556-336c1e9746a7"), 25, "John", "Doe", "Male" },
                    { new Guid("30f4105d-fe87-43cf-a4fa-d6d15541c9ff"), 20, "Charlie", "Dupa", "Other" },
                    { new Guid("cf8bc349-2e20-4a1b-ac63-4722dff73502"), 53, "Alice", "Doe", "Female" },
                    { new Guid("d6fad965-d98f-4bf5-878c-7644b0b139d4"), 59, "Bob", "Doe", "Male" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("115bf8ee-142c-42ce-8fc9-83bc47c1ae6c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2d88d221-75a3-416a-8556-336c1e9746a7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("30f4105d-fe87-43cf-a4fa-d6d15541c9ff"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("cf8bc349-2e20-4a1b-ac63-4722dff73502"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d6fad965-d98f-4bf5-878c-7644b0b139d4"));
        }
    }
}
