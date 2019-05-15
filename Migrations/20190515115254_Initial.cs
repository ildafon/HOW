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
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    FromVisitor = table.Column<bool>(nullable: false),
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
                    { 1L, "Dobroda.ru" },
                    { 2L, "Test" }
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
                    { 2L, 1L },
                    { 1L, 2L },
                    { 2L, 2L }
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
                columns: new[] { "MessageId", "ChatId", "Content", "FromVisitor", "Timestamp" },
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
