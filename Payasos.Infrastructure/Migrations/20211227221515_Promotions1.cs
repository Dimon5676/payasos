using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payasos.Infrastructure.Migrations
{
    public partial class Promotions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleWantedId",
                table: "PromotionRequests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PromotionRequests",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromotionRequests_RoleWantedId",
                table: "PromotionRequests",
                column: "RoleWantedId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionRequests_UserId",
                table: "PromotionRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionRequests_AspNetUsers_UserId",
                table: "PromotionRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionRequests_Role_RoleWantedId",
                table: "PromotionRequests",
                column: "RoleWantedId",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionRequests_AspNetUsers_UserId",
                table: "PromotionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionRequests_Role_RoleWantedId",
                table: "PromotionRequests");

            migrationBuilder.DropIndex(
                name: "IX_PromotionRequests_RoleWantedId",
                table: "PromotionRequests");

            migrationBuilder.DropIndex(
                name: "IX_PromotionRequests_UserId",
                table: "PromotionRequests");

            migrationBuilder.DropColumn(
                name: "RoleWantedId",
                table: "PromotionRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PromotionRequests");
        }
    }
}
