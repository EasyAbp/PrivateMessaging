using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.PrivateMessaging.Migrations
{
    public partial class AddedFromUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessages_CreatorId",
                table: "PmPrivateMessages");

            migrationBuilder.AddColumn<Guid>(
                name: "FromUserId",
                table: "PmPrivateMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_FromUserId",
                table: "PmPrivateMessages",
                column: "FromUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PmPrivateMessages_FromUserId",
                table: "PmPrivateMessages");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "PmPrivateMessages");

            migrationBuilder.CreateIndex(
                name: "IX_PmPrivateMessages_CreatorId",
                table: "PmPrivateMessages",
                column: "CreatorId");
        }
    }
}
