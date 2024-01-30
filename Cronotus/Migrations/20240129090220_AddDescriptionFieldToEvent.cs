using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionFieldToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d919976-1462-4e36-a6ba-0e8b48234f99", null, "Player", "PLAYER" },
                    { "2103ace8-2517-449c-9d87-569762079713", null, "Admin", "ADMIN" },
                    { "297b9521-e743-43dd-b7d4-686be922526c", null, "Organizer", "ORGANIZER" },
                    { "d1bc0f09-163b-40e8-8d05-32eda9142bcd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d919976-1462-4e36-a6ba-0e8b48234f99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2103ace8-2517-449c-9d87-569762079713");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297b9521-e743-43dd-b7d4-686be922526c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1bc0f09-163b-40e8-8d05-32eda9142bcd");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

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
    }
}
