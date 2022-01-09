using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Payasos.Infrastructure.Migrations
{
    public partial class Promotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromotionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HardSkillsExpertId = table.Column<string>(type: "text", nullable: true),
                    SoftSkillsExpertId = table.Column<string>(type: "text", nullable: true),
                    EnglishExpertId = table.Column<string>(type: "text", nullable: true),
                    HardSkillPass = table.Column<bool>(type: "boolean", nullable: false),
                    SoftSkillPass = table.Column<bool>(type: "boolean", nullable: false),
                    EnglishPass = table.Column<bool>(type: "boolean", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionRequests_AspNetUsers_EnglishExpertId",
                        column: x => x.EnglishExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromotionRequests_AspNetUsers_HardSkillsExpertId",
                        column: x => x.HardSkillsExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromotionRequests_AspNetUsers_SoftSkillsExpertId",
                        column: x => x.SoftSkillsExpertId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionRequests_EnglishExpertId",
                table: "PromotionRequests",
                column: "EnglishExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionRequests_HardSkillsExpertId",
                table: "PromotionRequests",
                column: "HardSkillsExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionRequests_SoftSkillsExpertId",
                table: "PromotionRequests",
                column: "SoftSkillsExpertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionRequests");
        }
    }
}
