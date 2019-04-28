using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduCoreApp.Data.EF.Migrations
{
    public partial class changeall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrtherPageHome",
                table: "Slides");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrtherPageHome",
                table: "Slides",
                nullable: false,
                defaultValue: false);
        }
    }
}
