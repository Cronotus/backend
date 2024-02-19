using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryIdToPlayersOnEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "InstanceId",
                table: "PlayersOnEvents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04871e77-2698-4b7e-809c-bfd25001c349", null, "User", "USER" },
                    { "5d12a66b-ebae-4137-b5b9-9dd04c8e6eca", null, "Organizer", "ORGANIZER" },
                    { "6a925e40-33fd-499b-9e4f-4faebc90a069", null, "Player", "PLAYER" },
                    { "d6135eb1-5211-47c9-875b-2bc9160d55f8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("0bbf2f01-15d6-483f-88c1-0555f392fbb3"), "Softball" },
                    { new Guid("22d90c0a-5b4b-46bc-aaea-95d04d96e33d"), "Badminton" },
                    { new Guid("3e0d023f-81ae-4250-a76f-438d45d986b4"), "Baseball" },
                    { new Guid("4b3e2b29-259c-4804-a655-5adf8229057f"), "Lacrosse" },
                    { new Guid("5bfc5272-8228-4415-9de8-57362d04f716"), "Frisbee" },
                    { new Guid("68852178-8795-4055-a28f-945453cf3051"), "Table Tennis" },
                    { new Guid("6ad94677-17dc-47ae-9a95-1a7f37ebfc88"), "Ice Hockey" },
                    { new Guid("6ce1b032-2e64-4a61-8ede-7ba8461a832a"), "Tennis" },
                    { new Guid("6dc2acb1-b5e2-417e-a7ad-b71b1966ed24"), "Handball" },
                    { new Guid("8631b209-37b0-418f-bbbd-9ab9f10d694e"), "Cricket" },
                    { new Guid("9eadfab0-30fe-46ff-b204-5b1c6b43b895"), "Football" },
                    { new Guid("9f62a64d-d174-4aae-a9e6-83cca65aad6f"), "Rugby" },
                    { new Guid("b135e2ce-9390-4cf2-be5f-e0de394dd102"), "Basketball" },
                    { new Guid("ba44b65d-75a6-40ff-8bcb-6ddfb86a783a"), "Volleyball" },
                    { new Guid("ce52d759-410e-43b9-92ba-57093ebb6f98"), "Field Hockey" },
                    { new Guid("d3f52746-d094-404b-b518-7e544a2b5b69"), "American Football" },
                    { new Guid("e89341f2-aa5b-44d5-a814-7ea300c8b52b"), "Water Polo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04871e77-2698-4b7e-809c-bfd25001c349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d12a66b-ebae-4137-b5b9-9dd04c8e6eca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a925e40-33fd-499b-9e4f-4faebc90a069");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6135eb1-5211-47c9-875b-2bc9160d55f8");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0bbf2f01-15d6-483f-88c1-0555f392fbb3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("22d90c0a-5b4b-46bc-aaea-95d04d96e33d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("3e0d023f-81ae-4250-a76f-438d45d986b4"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("4b3e2b29-259c-4804-a655-5adf8229057f"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("5bfc5272-8228-4415-9de8-57362d04f716"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("68852178-8795-4055-a28f-945453cf3051"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("6ad94677-17dc-47ae-9a95-1a7f37ebfc88"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("6ce1b032-2e64-4a61-8ede-7ba8461a832a"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("6dc2acb1-b5e2-417e-a7ad-b71b1966ed24"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("8631b209-37b0-418f-bbbd-9ab9f10d694e"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9eadfab0-30fe-46ff-b204-5b1c6b43b895"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9f62a64d-d174-4aae-a9e6-83cca65aad6f"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("b135e2ce-9390-4cf2-be5f-e0de394dd102"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("ba44b65d-75a6-40ff-8bcb-6ddfb86a783a"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("ce52d759-410e-43b9-92ba-57093ebb6f98"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d3f52746-d094-404b-b518-7e544a2b5b69"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("e89341f2-aa5b-44d5-a814-7ea300c8b52b"));

            migrationBuilder.DropColumn(
                name: "InstanceId",
                table: "PlayersOnEvents");

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
    }
}
