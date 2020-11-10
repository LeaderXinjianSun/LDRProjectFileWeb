using Microsoft.EntityFrameworkCore.Migrations;

namespace LDRProjectFileWeb.Migrations
{
    public partial class addFileSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileSize",
                table: "Documents",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Documents");
        }
    }
}
