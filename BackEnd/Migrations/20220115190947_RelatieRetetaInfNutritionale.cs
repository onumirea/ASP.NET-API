using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieRetetaInfNutritionale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetetaId",
                table: "Informatii_Nutritionale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Informatii_Nutritionale_RetetaId",
                table: "Informatii_Nutritionale",
                column: "RetetaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Informatii_Nutritionale_Retete_RetetaId",
                table: "Informatii_Nutritionale",
                column: "RetetaId",
                principalTable: "Retete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informatii_Nutritionale_Retete_RetetaId",
                table: "Informatii_Nutritionale");

            migrationBuilder.DropIndex(
                name: "IX_Informatii_Nutritionale_RetetaId",
                table: "Informatii_Nutritionale");

            migrationBuilder.DropColumn(
                name: "RetetaId",
                table: "Informatii_Nutritionale");
        }
    }
}
