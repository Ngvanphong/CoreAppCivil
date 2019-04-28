using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduCoreApp.Data.EF.Migrations
{
    public partial class changepantner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "PantnerId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products",
                column: "PantnerId",
                principalTable: "Pantners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "PantnerId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Pantners_PantnerId",
                table: "Products",
                column: "PantnerId",
                principalTable: "Pantners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
