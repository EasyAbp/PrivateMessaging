using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.PrivateMessaging.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmPrivateMessageNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    PrivateMessageId = table.Column<Guid>(nullable: false),
                    TitlePreview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPrivateMessageNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PmPrivateMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ToUserId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ReadTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmPrivateMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessageNotifications_PrivateMessageId",
                table: "PmPrivateMessageNotifications",
                column: "PrivateMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessageNotifications_UserId",
                table: "PmPrivateMessageNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_CreatorId",
                table: "PmPrivateMessages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_ToUserId",
                table: "PmPrivateMessages",
                column: "ToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmPrivateMessageNotifications");

            migrationBuilder.DropTable(
                name: "PmPrivateMessages");
        }
    }
}
