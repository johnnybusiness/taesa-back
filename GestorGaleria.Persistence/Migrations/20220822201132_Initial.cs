using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorGaleria.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcessaoID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galerias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concessao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gallery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Elaborador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdFotos = table.Column<int>(type: "int", nullable: false),
                    ImagemURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galerias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiposDeGaleria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concessoes");

            migrationBuilder.DropTable(
                name: "Galerias");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
