using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.API.Migrations
{
    public partial class AddBrandTableAnnRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "BModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BModels_BrandId",
                table: "BModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Description",
                table: "Brands",
                column: "Description",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BModels_Brands_BrandId",
                table: "BModels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_BModels_BrandId",
                table: "BModels");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "BModels");
        }
    }
}
