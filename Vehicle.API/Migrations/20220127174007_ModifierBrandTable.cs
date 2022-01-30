using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.API.Migrations
{
    public partial class ModifierBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "BModels",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "BModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
