using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AddedProfileImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ProfileCoverImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54e8bcb3-747a-4f11-a144-638df5b2a67a", null, "User", "USER" },
                    { "5691d6a2-34d3-46bc-ab6f-3c1eaa924844", null, "Organizer", "ORGANIZER" },
                    { "9886fba0-41be-4649-b62e-0dbe7572b882", null, "Player", "PLAYER" },
                    { "ceb86f51-ff97-49b9-984d-62f8f1c571a4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("0906101d-f490-4c0e-8463-197c353a9f98"), "Rugby" },
                    { new Guid("0f80c10e-50e6-4108-8d98-3fedf6ead6b9"), "Basketball" },
                    { new Guid("36488345-a190-479e-b7f9-98ae6b746187"), "Water Polo" },
                    { new Guid("4006b960-2a38-456d-944c-ea683359dd39"), "Field Hockey" },
                    { new Guid("49764de6-674e-44c4-a070-7f2304dfe972"), "Table Tennis" },
                    { new Guid("5ac6836a-2f19-4d4b-a321-fbb0156bf926"), "Tennis" },
                    { new Guid("76fed4ec-023c-489c-9d1e-bb0c42186a72"), "American Football" },
                    { new Guid("9b6a01bc-de0c-423d-b56b-cfb8ccf89b31"), "Softball" },
                    { new Guid("9cd9682d-04ea-4383-bcc9-d33a1eec63c3"), "Frisbee" },
                    { new Guid("9dc6d934-0d8b-45c9-a8f7-296e2c679ee3"), "Football" },
                    { new Guid("a2e993e9-5b8a-40b6-95e3-f9042a06862e"), "Ice Hockey" },
                    { new Guid("a434ac8a-2703-468f-987f-96632497aa1d"), "Cricket" },
                    { new Guid("a5c7abad-734a-4fc1-8206-853d42b4b7ed"), "Lacrosse" },
                    { new Guid("d6ea1d11-77d1-4051-ba72-141d02853181"), "Badminton" },
                    { new Guid("d7366526-7883-4b1d-9436-592c67f5da20"), "Handball" },
                    { new Guid("df1836ca-05aa-4c0d-b696-61a1224b10b3"), "Baseball" },
                    { new Guid("f978a529-f24c-4f1e-a55d-58973e0bce1b"), "Volleyball" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54e8bcb3-747a-4f11-a144-638df5b2a67a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5691d6a2-34d3-46bc-ab6f-3c1eaa924844");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9886fba0-41be-4649-b62e-0dbe7572b882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceb86f51-ff97-49b9-984d-62f8f1c571a4");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0906101d-f490-4c0e-8463-197c353a9f98"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0f80c10e-50e6-4108-8d98-3fedf6ead6b9"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("36488345-a190-479e-b7f9-98ae6b746187"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("4006b960-2a38-456d-944c-ea683359dd39"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("49764de6-674e-44c4-a070-7f2304dfe972"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("5ac6836a-2f19-4d4b-a321-fbb0156bf926"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("76fed4ec-023c-489c-9d1e-bb0c42186a72"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9b6a01bc-de0c-423d-b56b-cfb8ccf89b31"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9cd9682d-04ea-4383-bcc9-d33a1eec63c3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9dc6d934-0d8b-45c9-a8f7-296e2c679ee3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a2e993e9-5b8a-40b6-95e3-f9042a06862e"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a434ac8a-2703-468f-987f-96632497aa1d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a5c7abad-734a-4fc1-8206-853d42b4b7ed"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d6ea1d11-77d1-4051-ba72-141d02853181"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d7366526-7883-4b1d-9436-592c67f5da20"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("df1836ca-05aa-4c0d-b696-61a1224b10b3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f978a529-f24c-4f1e-a55d-58973e0bce1b"));

            migrationBuilder.DropColumn(
                name: "ProfileCoverImage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

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
    }
}
