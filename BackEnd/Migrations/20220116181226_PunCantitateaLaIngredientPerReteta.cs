using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class PunCantitateaLaIngredientPerReteta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "RetetaIngrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "RetetaIngrediente");
        }
    }
}
