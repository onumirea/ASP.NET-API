using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_O_A.Migrations
{
    public partial class CreareRetete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad_Dificultate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durata_minute = table.Column<int>(type: "int", nullable: false),
                    Numar_portii = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bucatarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mod_preparare = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retete", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retete");
        }
    }
}
