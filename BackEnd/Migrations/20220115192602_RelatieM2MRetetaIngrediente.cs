using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieM2MRetetaIngrediente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetetaIngrediente",
                columns: table => new
                {
                    RetetaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetetaIngrediente", x => new { x.RetetaId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_RetetaIngrediente_Ingrediente_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetetaIngrediente_Retete_RetetaId",
                        column: x => x.RetetaId,
                        principalTable: "Retete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetetaIngrediente_IngredientId",
                table: "RetetaIngrediente",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetetaIngrediente");
        }
    }
}
