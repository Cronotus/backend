using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cronotus.Migrations
{
    /// <inheritdoc />
    public partial class AddEventPicture2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EventPictures",
                columns: table => new
                {
                    EventPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPictures", x => x.EventPictureId);
                    table.ForeignKey(
                        name: "FK_EventPictures_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27004d6c-56cc-422f-8e31-d326037e221f", null, "User", "USER" },
                    { "3afbd140-7c77-49b0-be48-24f7c7af4eb8", null, "Admin", "ADMIN" },
                    { "5acdefa4-db1b-4779-a0a0-b3d9787b1fa2", null, "Player", "PLAYER" },
                    { "6e688725-ba77-476c-812f-124fedc188cf", null, "Organizer", "ORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { new Guid("06d44d89-a439-46c6-8598-50fe1cc4dbbc"), "Lacrosse" },
                    { new Guid("0802646b-0c50-47ec-bda7-720d6e727255"), "Volleyball" },
                    { new Guid("24c592a3-182f-4fca-bde8-314912071ae1"), "Rugby" },
                    { new Guid("4a6e7ec9-f8fc-48e0-ac14-88adb34c256a"), "Handball" },
                    { new Guid("5c9f3abc-4548-4e81-9250-8e0dff6566c3"), "Field Hockey" },
                    { new Guid("6a832d3c-ce78-43d5-9d95-3aa470e7be86"), "Badminton" },
                    { new Guid("838c1e25-583e-463f-b9f2-4a3a5068786e"), "Cricket" },
                    { new Guid("86e0dcdf-afc4-4a54-bace-8d73b3ec290d"), "Water Polo" },
                    { new Guid("8e45b516-fb06-4d10-bd5d-e99a22aa5926"), "Table Tennis" },
                    { new Guid("93e53800-4c01-4830-af57-82ed2cd930be"), "Baseball" },
                    { new Guid("988127e0-fa33-437a-b885-155374b4f5fb"), "Frisbee" },
                    { new Guid("a1a8297d-6a3c-4f4f-a333-87ca5fbf282d"), "Ice Hockey" },
                    { new Guid("a4ff0498-a348-4c88-8c55-678ed8619b47"), "American Football" },
                    { new Guid("bde24431-7fed-4dc3-ad44-29940eb62780"), "Tennis" },
                    { new Guid("cc686fad-f71b-4a5f-b2b6-ccbb369e27f2"), "Football" },
                    { new Guid("d2a07c19-e15a-4ab6-9540-69f5aacb0a8d"), "Softball" },
                    { new Guid("e9bb0ec3-c98a-45a4-beb2-b27f9f7427a3"), "Basketball" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPictures_EventId",
                table: "EventPictures",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPictures");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27004d6c-56cc-422f-8e31-d326037e221f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3afbd140-7c77-49b0-be48-24f7c7af4eb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5acdefa4-db1b-4779-a0a0-b3d9787b1fa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e688725-ba77-476c-812f-124fedc188cf");

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("06d44d89-a439-46c6-8598-50fe1cc4dbbc"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("0802646b-0c50-47ec-bda7-720d6e727255"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("24c592a3-182f-4fca-bde8-314912071ae1"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("4a6e7ec9-f8fc-48e0-ac14-88adb34c256a"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("5c9f3abc-4548-4e81-9250-8e0dff6566c3"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("6a832d3c-ce78-43d5-9d95-3aa470e7be86"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("838c1e25-583e-463f-b9f2-4a3a5068786e"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("86e0dcdf-afc4-4a54-bace-8d73b3ec290d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("8e45b516-fb06-4d10-bd5d-e99a22aa5926"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("93e53800-4c01-4830-af57-82ed2cd930be"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("988127e0-fa33-437a-b885-155374b4f5fb"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a1a8297d-6a3c-4f4f-a333-87ca5fbf282d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("a4ff0498-a348-4c88-8c55-678ed8619b47"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("bde24431-7fed-4dc3-ad44-29940eb62780"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("cc686fad-f71b-4a5f-b2b6-ccbb369e27f2"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("d2a07c19-e15a-4ab6-9540-69f5aacb0a8d"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "SportId",
                keyValue: new Guid("e9bb0ec3-c98a-45a4-beb2-b27f9f7427a3"));

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
    }
}
