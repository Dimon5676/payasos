using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payasos.Infrastructure.Migrations
{
    public partial class PromotionRequestChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InterviewDate",
                table: "PromotionRequests",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "PromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "PromotionRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InterviewDate",
                table: "PromotionRequests",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
