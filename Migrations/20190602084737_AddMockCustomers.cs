using Microsoft.EntityFrameworkCore.Migrations;

namespace HoustonOnWire.Migrations
{
    public partial class AddMockCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Avatars",
                columns: new[] { "AvatarId", "Url" },
                values: new object[,]
                {
                    { 5L, "/assets/av-5.png" },
                    { 6L, "/assets/av-6.png" },
                    { 7L, "/assets/av-7.png" },
                    { 8L, "/assets/av-8.png" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AvatarId", "Email", "Name" },
                values: new object[] { 3L, 5L, "operator3@example.com", "Operator3" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AvatarId", "Email", "Name" },
                values: new object[] { 4L, 6L, "operator4@example.com", "Operator4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Avatars",
                keyColumn: "AvatarId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Avatars",
                keyColumn: "AvatarId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Avatars",
                keyColumn: "AvatarId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Avatars",
                keyColumn: "AvatarId",
                keyValue: 6L);
        }
    }
}
