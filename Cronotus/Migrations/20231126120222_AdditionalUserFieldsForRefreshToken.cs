using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFieldsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c238b7-5596-4665-bb79-f6104ab14e61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7521e4e3-9a7f-4294-b32d-fdd9980cc589");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ae3b13-d19c-4dad-aa71-5de400359352");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48bc45df-bcf0-4684-ba5f-5ce6dc7b818e", null, "Player", "PLAYER" },
                    { "8fc2031b-4fa0-4eea-8a72-c99fc5d1d3fd", null, "Admin", "ADMIN" },
                    { "f80ee957-9b1e-4a4a-81cb-3893c367218c", null, "Organizer", "ORGANIZER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48bc45df-bcf0-4684-ba5f-5ce6dc7b818e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fc2031b-4fa0-4eea-8a72-c99fc5d1d3fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80ee957-9b1e-4a4a-81cb-3893c367218c");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50c238b7-5596-4665-bb79-f6104ab14e61", null, "Organizer", "ORGANIZER" },
                    { "7521e4e3-9a7f-4294-b32d-fdd9980cc589", null, "Player", "PLAYER" },
                    { "b3ae3b13-d19c-4dad-aa71-5de400359352", null, "Admin", "ADMIN" }
                });
        }
    }
}
