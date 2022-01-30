using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehicle.API.Migrations
{
    public partial class AddTableProcedureIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Procedures_Description",
                table: "Procedures",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_Description",
                table: "Procedures");
        }
    }
}
