using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AddEventPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dc57b0b-c59a-4b30-a6d5-0531db91c55a", null, "User", "USER" },
                    { "1e33cb3e-5e9b-4f68-a7ea-fafabfb215d5", null, "Player", "PLAYER" },
                    { "970e5328-9f23-45d0-95a2-18f7e4b331f6", null, "Admin", "ADMIN" },
                    { "e6141e74-165e-40c2-b0b6-96a822a74b6f", null, "Organizer", "ORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("08c9532c-ad94-442e-9225-a52f75380755"), "Tennis" },
                    { new Guid("0acb8960-ef8c-454a-bde3-91bda6b2a0a9"), "Handball" },
                    { new Guid("245ae97e-d621-4783-8247-3e065fdf35fc"), "Rugby" },
                    { new Guid("2698cd6b-9ab0-416b-ba46-0a46171eb6ff"), "Field Hockey" },
                    { new Guid("38be52e0-9c31-40f4-afc2-9c75914acff7"), "Softball" },
                    { new Guid("672bf206-6a41-4415-9aa4-f0063dfcdac5"), "Badminton" },
                    { new Guid("758d623a-06d3-4aa6-abbe-da3d42f7ea77"), "Table Tennis" },
                    { new Guid("803f115a-d211-4e19-bf10-a0f1c06976df"), "Water Polo" },
                    { new Guid("913ef8ee-e9f0-4fcb-b0c9-224bb514e041"), "Lacrosse" },
                    { new Guid("9727999f-5444-4831-87fb-ee952702bade"), "American Football" },
                    { new Guid("9b8f6414-0371-4b21-aefc-b3c07a2186be"), "Cricket" },
                    { new Guid("9f48c5ab-cdbd-48b8-a5d1-9ee0a702f586"), "Volleyball" },
                    { new Guid("be0c4934-2768-4b51-bb87-db651d2560e0"), "Baseball" },
                    { new Guid("d42c6366-abdc-4778-88d1-53fe17c9d280"), "Football" },
                    { new Guid("dfc13d19-44f8-40f5-bc28-71f007bca735"), "Ice Hockey" },
                    { new Guid("f6b63750-d79e-41ae-8b22-af2255825706"), "Frisbee" },
                    { new Guid("febdf526-7b41-496d-8fcd-36e948248e65"), "Basketball" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dc57b0b-c59a-4b30-a6d5-0531db91c55a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e33cb3e-5e9b-4f68-a7ea-fafabfb215d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "970e5328-9f23-45d0-95a2-18f7e4b331f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6141e74-165e-40c2-b0b6-96a822a74b6f");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("08c9532c-ad94-442e-9225-a52f75380755"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0acb8960-ef8c-454a-bde3-91bda6b2a0a9"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("245ae97e-d621-4783-8247-3e065fdf35fc"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("2698cd6b-9ab0-416b-ba46-0a46171eb6ff"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("38be52e0-9c31-40f4-afc2-9c75914acff7"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("672bf206-6a41-4415-9aa4-f0063dfcdac5"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("758d623a-06d3-4aa6-abbe-da3d42f7ea77"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("803f115a-d211-4e19-bf10-a0f1c06976df"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("913ef8ee-e9f0-4fcb-b0c9-224bb514e041"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9727999f-5444-4831-87fb-ee952702bade"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9b8f6414-0371-4b21-aefc-b3c07a2186be"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("9f48c5ab-cdbd-48b8-a5d1-9ee0a702f586"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("be0c4934-2768-4b51-bb87-db651d2560e0"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d42c6366-abdc-4778-88d1-53fe17c9d280"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("dfc13d19-44f8-40f5-bc28-71f007bca735"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("f6b63750-d79e-41ae-8b22-af2255825706"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("febdf526-7b41-496d-8fcd-36e948248e65"));

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
    }
}
