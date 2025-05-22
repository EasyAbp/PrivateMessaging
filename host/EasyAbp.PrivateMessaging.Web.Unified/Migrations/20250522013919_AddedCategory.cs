using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.PrivateMessaging.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PmPrivateMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PmPrivateMessageNotifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_ToUserId_Category",
                table: "PmPrivateMessages",
                columns: new[] { "ToUserId", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessageNotifications_UserId_Category",
                table: "PmPrivateMessageNotifications",
                columns: new[] { "UserId", "Category" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessages_ToUserId_Category",
                table: "PmPrivateMessages");

            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessageNotifications_UserId_Category",
                table: "PmPrivateMessageNotifications");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "PmPrivateMessages");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "PmPrivateMessageNotifications");
        }
    }
}
