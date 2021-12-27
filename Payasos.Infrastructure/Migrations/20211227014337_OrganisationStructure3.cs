using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payasos.Infrastructure.Migrations
{
    public partial class OrganisationStructure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultRoleId",
                table: "Organizations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultRoleId",
                table: "Organizations");
        }
    }
}
