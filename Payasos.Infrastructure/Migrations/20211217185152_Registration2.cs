using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payasos.Infrastructure.Migrations
{
    public partial class Registration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Organizations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Organizations");
        }
    }
}
