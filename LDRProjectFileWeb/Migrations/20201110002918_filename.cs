using Microsoft.EntityFrameworkCore.Migrations;

namespace LDRProjectFileWeb.Migrations
{
    public partial class filename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");
        }
    }
}
