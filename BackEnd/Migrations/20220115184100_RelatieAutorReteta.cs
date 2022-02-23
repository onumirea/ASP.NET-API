using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieAutorReteta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Retete",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Retete_AutorId",
                table: "Retete",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retete_Autori_AutorId",
                table: "Retete",
                column: "AutorId",
                principalTable: "Autori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retete_Autori_AutorId",
                table: "Retete");

            migrationBuilder.DropIndex(
                name: "IX_Retete_AutorId",
                table: "Retete");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Retete");
        }
    }
}
