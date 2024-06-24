using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class RemovedKeylessPropFromPlayersOnEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayersOnEvents",
                table: "PlayersOnEvents",
                column: "InstanceId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10a069c5-f8b3-4fb0-b2e5-d489a9edd545", null, "Organizer", "ORGANIZER" },
                    { "54cdc3cf-2898-4bdd-8c86-a78283d33f75", null, "Player", "PLAYER" },
                    { "be6febb6-68ea-4325-abcd-aea206515944", null, "User", "USER" },
                    { "c1c879d5-ef1b-47b7-aa29-d7008b14bbea", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("262eb951-6cb3-4a78-97e2-6298dd9c9e4c"), "Basketball" },
                    { new Guid("32c92572-c0bb-40b5-bc9e-4138864baff1"), "Badminton" },
                    { new Guid("8b88280f-24ee-4656-ab41-aee876179f13"), "Rugby" },
                    { new Guid("8fc5a368-84a2-4438-9733-ae51a7588204"), "Field Hockey" },
                    { new Guid("9af87922-32ad-402c-8952-db1f450254d8"), "Football" },
                    { new Guid("9d48066d-a44f-4590-957b-30a31e5da4e1"), "Volleyball" },
                    { new Guid("a464fdc0-9091-45c6-83eb-e02b96acf721"), "Frisbee" },
                    { new Guid("a769209f-1130-4ee0-b5d1-d492c7de3dbb"), "Baseball" },
                    { new Guid("ac6badb6-c92a-4ab1-8be7-95e9c53bac7d"), "American Football" },
                    { new Guid("d6840a9e-095d-42b3-b907-e6c9478acdf0"), "Ice Hockey" },
                    { new Guid("e4b1d400-7816-4d3f-941e-14a1e9de2028"), "Cricket" },
                    { new Guid("e618724f-c485-4dd3-9428-13b8eeeed299"), "Table Tennis" },
                    { new Guid("f091a7d7-ea50-44da-913f-ce912f8df645"), "Water Polo" },
                    { new Guid("f472de91-a153-492f-9c4d-205154fab3ba"), "Handball" },
                    { new Guid("f4b67f62-73b1-425a-8dcf-9de28d420d45"), "Tennis" },
                    { new Guid("f4b83a98-396f-4b8a-9153-d61ba01cd66f"), "Lacrosse" },
                    { new Guid("fcf58936-819d-4f47-a0b3-ec891ee1da5d"), "Softball" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayersOnEvents",
                table: "PlayersOnEvents");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10a069c5-f8b3-4fb0-b2e5-d489a9edd545");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54cdc3cf-2898-4bdd-8c86-a78283d33f75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be6febb6-68ea-4325-abcd-aea206515944");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1c879d5-ef1b-47b7-aa29-d7008b14bbea");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("262eb951-6cb3-4a78-97e2-6298dd9c9e4c"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("32c92572-c0bb-40b5-bc9e-4138864baff1"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("8b88280f-24ee-4656-ab41-aee876179f13"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("8fc5a368-84a2-4438-9733-ae51a7588204"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9af87922-32ad-402c-8952-db1f450254d8"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9d48066d-a44f-4590-957b-30a31e5da4e1"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a464fdc0-9091-45c6-83eb-e02b96acf721"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a769209f-1130-4ee0-b5d1-d492c7de3dbb"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("ac6badb6-c92a-4ab1-8be7-95e9c53bac7d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d6840a9e-095d-42b3-b907-e6c9478acdf0"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("e4b1d400-7816-4d3f-941e-14a1e9de2028"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("e618724f-c485-4dd3-9428-13b8eeeed299"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f091a7d7-ea50-44da-913f-ce912f8df645"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f472de91-a153-492f-9c4d-205154fab3ba"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f4b67f62-73b1-425a-8dcf-9de28d420d45"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f4b83a98-396f-4b8a-9153-d61ba01cd66f"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("fcf58936-819d-4f47-a0b3-ec891ee1da5d"));

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
    }
}
