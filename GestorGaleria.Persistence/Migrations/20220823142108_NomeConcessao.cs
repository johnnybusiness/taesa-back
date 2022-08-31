using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorGaleria.Persistence.Migrations
{
    public partial class NomeConcessao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConcessaoID",
                table: "Concessoes",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Concessoes",
                newName: "ConcessaoID");
        }
    }
}
