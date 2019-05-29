using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoustonOnWire.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    AvatarId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.AvatarId);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ChannelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ChannelId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AvatarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "AvatarId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    AvatarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_Visitors_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "AvatarId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ChannelCustomers",
                columns: table => new
                {
                    ChannelId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelCustomers", x => new { x.ChannelId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ChannelCustomers_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    CustomerFirstResponse = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: true),
                    VisitorId = table.Column<long>(nullable: false),
                    LastMessageId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    FromVisitor = table.Column<bool>(nullable: false),
                    Received = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ChatId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Avatars",
                columns: new[] { "AvatarId", "Url" },
                values: new object[,]
                {
                    { 1L, "/assets/av-1.png" },
                    { 2L, "/assets/av-2.png" },
                    { 3L, "/assets/av-3.png" },
                    { 4L, "/assets/av-4.png" }
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "ChannelId", "Name" },
                values: new object[,]
                {
                    { 27L, "Test27" },
                    { 28L, "Test28" },
                    { 29L, "Test29" },
                    { 30L, "Test30" },
                    { 31L, "Test31" },
                    { 32L, "Test32" },
                    { 33L, "Test33" },
                    { 34L, "Test34" },
                    { 35L, "Test35" },
                    { 36L, "Test36" },
                    { 37L, "Test37" },
                    { 39L, "Test39" },
                    { 26L, "Test26" },
                    { 40L, "Test40" },
                    { 41L, "Test41" },
                    { 42L, "Test42" },
                    { 43L, "Test43" },
                    { 44L, "Test44" },
                    { 45L, "Test45" },
                    { 46L, "Test46" },
                    { 47L, "Test47" },
                    { 48L, "Test48" },
                    { 38L, "Test38" },
                    { 25L, "Test25" },
                    { 23L, "Test23" },
                    { 49L, "Test49" },
                    { 1L, "Test1" },
                    { 2L, "Test2" },
                    { 3L, "Test3" },
                    { 4L, "Test4" },
                    { 5L, "Test5" },
                    { 6L, "Test6" },
                    { 7L, "Test7" },
                    { 8L, "Test8" },
                    { 9L, "Test9" },
                    { 10L, "Test10" },
                    { 24L, "Test24" },
                    { 11L, "Test11" },
                    { 13L, "Test13" },
                    { 14L, "Test14" },
                    { 15L, "Test15" },
                    { 16L, "Test16" },
                    { 17L, "Test17" },
                    { 18L, "Test18" },
                    { 19L, "Test19" },
                    { 20L, "Test20" },
                    { 21L, "Test21" },
                    { 22L, "Test22" },
                    { 12L, "Test12" },
                    { 50L, "Test50" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AvatarId", "Email", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "operator1@example.com", "Operator1" },
                    { 2L, 2L, "operator2@example.com", "Operator2" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "VisitorId", "AvatarId", "Comment", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1L, 3L, "Comment1", "visitor1@example.com", "Visitor1", "+79190000001" },
                    { 2L, 4L, "Comment2", "visitor2@example.com", "Visitor2", "+79190000002" }
                });

            migrationBuilder.InsertData(
                table: "ChannelCustomers",
                columns: new[] { "ChannelId", "CustomerId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 24L, 2L },
                    { 23L, 2L },
                    { 22L, 2L },
                    { 21L, 2L },
                    { 20L, 2L },
                    { 19L, 2L },
                    { 18L, 2L },
                    { 17L, 2L },
                    { 16L, 2L },
                    { 15L, 2L },
                    { 14L, 2L },
                    { 13L, 2L },
                    { 12L, 2L },
                    { 11L, 2L },
                    { 10L, 2L },
                    { 9L, 2L },
                    { 8L, 2L },
                    { 7L, 2L },
                    { 6L, 2L },
                    { 5L, 2L },
                    { 4L, 2L },
                    { 25L, 2L },
                    { 26L, 2L },
                    { 27L, 2L },
                    { 28L, 2L },
                    { 50L, 2L },
                    { 49L, 2L },
                    { 48L, 2L },
                    { 47L, 2L },
                    { 46L, 2L },
                    { 45L, 2L },
                    { 44L, 2L },
                    { 43L, 2L },
                    { 42L, 2L },
                    { 41L, 2L },
                    { 3L, 2L },
                    { 40L, 2L },
                    { 38L, 2L },
                    { 37L, 2L },
                    { 36L, 2L },
                    { 35L, 2L },
                    { 34L, 2L },
                    { 33L, 2L },
                    { 32L, 2L },
                    { 31L, 2L },
                    { 30L, 2L },
                    { 29L, 2L },
                    { 39L, 2L },
                    { 2L, 2L },
                    { 1L, 2L },
                    { 50L, 1L },
                    { 22L, 1L },
                    { 21L, 1L },
                    { 20L, 1L },
                    { 19L, 1L },
                    { 18L, 1L },
                    { 17L, 1L },
                    { 16L, 1L },
                    { 15L, 1L },
                    { 14L, 1L },
                    { 13L, 1L },
                    { 12L, 1L },
                    { 11L, 1L },
                    { 10L, 1L },
                    { 9L, 1L },
                    { 8L, 1L },
                    { 7L, 1L },
                    { 6L, 1L },
                    { 5L, 1L },
                    { 4L, 1L },
                    { 3L, 1L },
                    { 2L, 1L },
                    { 23L, 1L },
                    { 24L, 1L },
                    { 25L, 1L },
                    { 38L, 1L },
                    { 47L, 1L },
                    { 46L, 1L },
                    { 45L, 1L },
                    { 44L, 1L },
                    { 43L, 1L },
                    { 42L, 1L },
                    { 41L, 1L },
                    { 40L, 1L },
                    { 39L, 1L },
                    { 26L, 1L },
                    { 37L, 1L },
                    { 36L, 1L },
                    { 35L, 1L },
                    { 34L, 1L },
                    { 33L, 1L },
                    { 32L, 1L },
                    { 31L, 1L },
                    { 30L, 1L },
                    { 29L, 1L },
                    { 28L, 1L },
                    { 27L, 1L },
                    { 48L, 1L },
                    { 49L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "CustomerFirstResponse", "CustomerId", "IsActive", "LastMessageId", "Score", "VisitorId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, true, 2L, 10, 1L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, true, 4L, 5, 2L }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ChatId", "Content", "FromVisitor", "Received" },
                values: new object[,]
                {
                    { 1L, 1L, "Hello", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 1L, "Hello", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 2L, "Hello", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 2L, "Hello", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelCustomers_CustomerId",
                table: "ChannelCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CustomerId",
                table: "Chats",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_VisitorId",
                table: "Chats",
                column: "VisitorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AvatarId",
                table: "Customers",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_AvatarId",
                table: "Visitors",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelCustomers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Avatars");
        }
    }
}
