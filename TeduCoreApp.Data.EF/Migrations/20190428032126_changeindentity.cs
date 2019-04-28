using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduCoreApp.Data.EF.Migrations
{
    public partial class changeindentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
