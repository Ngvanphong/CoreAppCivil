using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduCoreApp.Data.EF.Migrations
{
    public partial class changepantner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Pantners");

            migrationBuilder.AddColumn<int>(
                name: "PantnerId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PantnerId",
                table: "Products",
                column: "PantnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products",
                column: "PantnerId",
                principalTable: "Pantners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PantnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PantnerId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Pantners",
                maxLength: 250,
                nullable: true);
        }
    }
}
