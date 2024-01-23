using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "127c0ed7-d45e-49d9-82fb-1d4bd81e88a2", null, "User", "USER" },
                    { "18a29c6c-2400-4335-8359-f8f7e75dc7f1", null, "Player", "PLAYER" },
                    { "1e385b2b-7c20-403e-a9bc-28049baa71d2", null, "Admin", "ADMIN" },
                    { "e6923d9b-1197-4508-9e10-42c12f335aa1", null, "Organizer", "ORGANIZER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "127c0ed7-d45e-49d9-82fb-1d4bd81e88a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18a29c6c-2400-4335-8359-f8f7e75dc7f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e385b2b-7c20-403e-a9bc-28049baa71d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6923d9b-1197-4508-9e10-42c12f335aa1");

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
    }
}
