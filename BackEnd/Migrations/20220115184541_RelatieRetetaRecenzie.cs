using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieRetetaRecenzie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetetaId",
                table: "Recenzii",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_RetetaId",
                table: "Recenzii",
                column: "RetetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzii_Retete_RetetaId",
                table: "Recenzii",
                column: "RetetaId",
                principalTable: "Retete",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzii_Retete_RetetaId",
                table: "Recenzii");

            migrationBuilder.DropIndex(
                name: "IX_Recenzii_RetetaId",
                table: "Recenzii");

            migrationBuilder.DropColumn(
                name: "RetetaId",
                table: "Recenzii");
        }
    }
}
