using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.PrivateMessaging.Migrations
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateMessagingPmUsers",
                schema: "PM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateMessagingPrivateMessages",
                schema: "PM",
                table: "PrivateMessagingPrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateMessagingPrivateMessageNotifications",
                schema: "PM",
                table: "PrivateMessagingPrivateMessageNotifications");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessages",
                schema: "PM",
                newName: "PmPrivateMessages");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessageNotifications",
                schema: "PM",
                newName: "PmPrivateMessageNotifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PmPrivateMessages",
                table: "PmPrivateMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PmPrivateMessageNotifications",
                table: "PmPrivateMessageNotifications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_CreatorId",
                table: "PmPrivateMessages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_ToUserId",
                table: "PmPrivateMessages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessageNotifications_PrivateMessageId",
                table: "PmPrivateMessageNotifications",
                column: "PrivateMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessageNotifications_UserId",
                table: "PmPrivateMessageNotifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PmPrivateMessages",
                table: "PmPrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessages_CreatorId",
                table: "PmPrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessages_ToUserId",
                table: "PmPrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PmPrivateMessageNotifications",
                table: "PmPrivateMessageNotifications");

            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessageNotifications_PrivateMessageId",
                table: "PmPrivateMessageNotifications");

            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessageNotifications_UserId",
                table: "PmPrivateMessageNotifications");

            migrationBuilder.EnsureSchema(
                name: "PM");

            migrationBuilder.RenameTable(
                name: "PmPrivateMessages",
                newName: "PrivateMessagingPrivateMessages",
                newSchema: "PM");

            migrationBuilder.RenameTable(
                name: "PmPrivateMessageNotifications",
                newName: "PrivateMessagingPrivateMessageNotifications",
                newSchema: "PM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateMessagingPrivateMessages",
                schema: "PM",
                table: "PrivateMessagingPrivateMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateMessagingPrivateMessageNotifications",
                schema: "PM",
                table: "PrivateMessagingPrivateMessageNotifications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PrivateMessagingPmUsers",
                schema: "PM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessagingPmUsers", x => x.Id);
                });
        }
    }
}
