using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.PrivateMessaging.Migrations
{
    public partial class AddedPmUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PM");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessages",
                newName: "PrivateMessagingPrivateMessages",
                newSchema: "PM");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessageNotifications",
                newName: "PrivateMessagingPrivateMessageNotifications",
                newSchema: "PM");

            migrationBuilder.CreateTable(
                name: "PrivateMessagingPmUsers",
                schema: "PM",
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
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessagingPmUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateMessagingPmUsers",
                schema: "PM");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessages",
                schema: "PM",
                newName: "PrivateMessagingPrivateMessages");

            migrationBuilder.RenameTable(
                name: "PrivateMessagingPrivateMessageNotifications",
                schema: "PM",
                newName: "PrivateMessagingPrivateMessageNotifications");
        }
    }
}
