using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class EliminandoReglaGeneros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_generos_nombre_genero",
                table: "generos");

            migrationBuilder.DropIndex(
                name: "IX_facultades_nombre",
                table: "facultades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_generos_nombre_genero",
                table: "generos",
                column: "nombre_genero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_facultades_nombre",
                table: "facultades",
                column: "nombre",
                unique: true);
        }
    }
}
