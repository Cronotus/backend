using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class SportsConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21e065ba-f290-4c06-b86e-4f8546dc1008", null, "Admin", "ADMIN" },
                    { "35781823-d2d1-4d2f-bbb4-500232df67c5", null, "Organizer", "ORGANIZER" },
                    { "a6d28996-051c-4e17-ae22-f3aafabc9d7c", null, "User", "USER" },
                    { "f271d5c5-e645-4846-9a35-a9699b767051", null, "Player", "PLAYER" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("0a44937f-dd36-4ab5-80b8-90da6a238ccb"), "American Football" },
                    { new Guid("0b1ee8ad-89f1-42d9-97ae-c00a11051da7"), "Tennis" },
                    { new Guid("0fad091a-961d-41c1-9c1a-1bd7e54325f0"), "Rugby" },
                    { new Guid("404f8c0f-2982-45cd-8dc2-e3868e7e9415"), "Water Polo" },
                    { new Guid("435d1f8a-9780-4d2c-a9d0-8ceaac333a8c"), "Table Tennis" },
                    { new Guid("45d8b1b3-b195-4367-a01e-226c1394e9c5"), "Volleyball" },
                    { new Guid("4dda6e6e-3f3b-4ffe-8261-a13a60972dd3"), "Baseball" },
                    { new Guid("56b9f4d3-b107-4c30-a3b5-736a6b04fb38"), "Softball" },
                    { new Guid("5e453b60-c372-4230-b47d-8f7a23e1751a"), "Field Hockey" },
                    { new Guid("972858af-1c36-4650-b562-f24c5b3b4a1f"), "Basketball" },
                    { new Guid("ad4768e5-c073-4586-9c4f-b5fc44d8d20b"), "Cricket" },
                    { new Guid("d1ead115-8686-49ea-b3d3-8a3ddc0d2d54"), "Badminton" },
                    { new Guid("d4dc68b1-7976-456a-a343-8b6bee744192"), "Football" },
                    { new Guid("d69944cf-e1a8-4134-9a33-7be7210873d5"), "Handball" },
                    { new Guid("d9bd61a7-0b5f-4db5-889c-a5bf1aea2514"), "Frisbee" },
                    { new Guid("f5eddaf2-e1a4-4f71-a90d-67da4801060b"), "Ice Hockey" },
                    { new Guid("f7656c81-1aa8-4c66-b836-1d33c2e572a7"), "Lacrosse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21e065ba-f290-4c06-b86e-4f8546dc1008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35781823-d2d1-4d2f-bbb4-500232df67c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6d28996-051c-4e17-ae22-f3aafabc9d7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f271d5c5-e645-4846-9a35-a9699b767051");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0a44937f-dd36-4ab5-80b8-90da6a238ccb"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0b1ee8ad-89f1-42d9-97ae-c00a11051da7"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0fad091a-961d-41c1-9c1a-1bd7e54325f0"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("404f8c0f-2982-45cd-8dc2-e3868e7e9415"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("435d1f8a-9780-4d2c-a9d0-8ceaac333a8c"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("45d8b1b3-b195-4367-a01e-226c1394e9c5"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("4dda6e6e-3f3b-4ffe-8261-a13a60972dd3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("56b9f4d3-b107-4c30-a3b5-736a6b04fb38"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("5e453b60-c372-4230-b47d-8f7a23e1751a"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("972858af-1c36-4650-b562-f24c5b3b4a1f"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("ad4768e5-c073-4586-9c4f-b5fc44d8d20b"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d1ead115-8686-49ea-b3d3-8a3ddc0d2d54"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d4dc68b1-7976-456a-a343-8b6bee744192"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d69944cf-e1a8-4134-9a33-7be7210873d5"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d9bd61a7-0b5f-4db5-889c-a5bf1aea2514"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f5eddaf2-e1a4-4f71-a90d-67da4801060b"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f7656c81-1aa8-4c66-b836-1d33c2e572a7"));

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
    }
}
