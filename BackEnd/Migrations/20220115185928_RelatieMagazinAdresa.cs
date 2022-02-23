using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class RelatieMagazinAdresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagazinId",
                table: "Adrese",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adrese_MagazinId",
                table: "Adrese",
                column: "MagazinId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adrese_Magazine_MagazinId",
                table: "Adrese",
                column: "MagazinId",
                principalTable: "Magazine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adrese_Magazine_MagazinId",
                table: "Adrese");

            migrationBuilder.DropIndex(
                name: "IX_Adrese_MagazinId",
                table: "Adrese");

            migrationBuilder.DropColumn(
                name: "MagazinId",
                table: "Adrese");
        }
    }
}
