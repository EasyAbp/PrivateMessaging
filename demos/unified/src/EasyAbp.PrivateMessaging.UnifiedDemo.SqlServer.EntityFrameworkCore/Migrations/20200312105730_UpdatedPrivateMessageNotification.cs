using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.PrivateMessaging.Migrations
{
    public partial class UpdatedPrivateMessageNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitlePreview",
                schema: "PM",
                table: "PrivateMessagingPrivateMessageNotifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitlePreview",
                schema: "PM",
                table: "PrivateMessagingPrivateMessageNotifications");
        }
    }
}
