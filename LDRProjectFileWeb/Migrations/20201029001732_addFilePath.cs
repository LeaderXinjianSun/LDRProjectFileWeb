using Microsoft.EntityFrameworkCore.Migrations;

namespace LDRProjectFileWeb.Migrations
{
    public partial class addFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Documents",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Documents");
        }
    }
}
