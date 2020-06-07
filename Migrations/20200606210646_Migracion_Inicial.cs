using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDisco.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    IdDisco = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    CantidadCanciones = table.Column<int>(nullable: false),
                    FechaLanzamiento = table.Column<DateTime>(nullable: false),
                    Artista = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.IdDisco);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discos");
        }
    }
}
