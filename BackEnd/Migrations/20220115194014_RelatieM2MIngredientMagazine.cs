using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieM2MIngredientMagazine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMagazin_Ingrediente_IngredientId",
                table: "IngredientMagazin");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMagazin_Magazine_MagazinId",
                table: "IngredientMagazin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientMagazin",
                table: "IngredientMagazin");

            migrationBuilder.RenameTable(
                name: "IngredientMagazin",
                newName: "IngredientMagazine");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientMagazin_MagazinId",
                table: "IngredientMagazine",
                newName: "IX_IngredientMagazine_MagazinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientMagazine",
                table: "IngredientMagazine",
                columns: new[] { "IngredientId", "MagazinId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMagazine_Ingrediente_IngredientId",
                table: "IngredientMagazine",
                column: "IngredientId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMagazine_Magazine_MagazinId",
                table: "IngredientMagazine",
                column: "MagazinId",
                principalTable: "Magazine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMagazine_Ingrediente_IngredientId",
                table: "IngredientMagazine");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientMagazine_Magazine_MagazinId",
                table: "IngredientMagazine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientMagazine",
                table: "IngredientMagazine");

            migrationBuilder.RenameTable(
                name: "IngredientMagazine",
                newName: "IngredientMagazin");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientMagazine_MagazinId",
                table: "IngredientMagazin",
                newName: "IX_IngredientMagazin_MagazinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientMagazin",
                table: "IngredientMagazin",
                columns: new[] { "IngredientId", "MagazinId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMagazin_Ingrediente_IngredientId",
                table: "IngredientMagazin",
                column: "IngredientId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientMagazin_Magazine_MagazinId",
                table: "IngredientMagazin",
                column: "MagazinId",
                principalTable: "Magazine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
