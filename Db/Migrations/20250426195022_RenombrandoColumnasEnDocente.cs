using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class RenombrandoColumnasEnDocente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_docentes_generos_genero",
                table: "docentes");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "docentes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "docentes",
                newName: "id_genero");

            migrationBuilder.RenameIndex(
                name: "IX_docentes_genero",
                table: "docentes",
                newName: "IX_docentes_id_genero");

            migrationBuilder.AddForeignKey(
                name: "FK_docentes_generos_id_genero",
                table: "docentes",
                column: "id_genero",
                principalTable: "generos",
                principalColumn: "id_genero",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_docentes_generos_id_genero",
                table: "docentes");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "docentes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id_genero",
                table: "docentes",
                newName: "genero");

            migrationBuilder.RenameIndex(
                name: "IX_docentes_id_genero",
                table: "docentes",
                newName: "IX_docentes_genero");

            migrationBuilder.AddForeignKey(
                name: "FK_docentes_generos_genero",
                table: "docentes",
                column: "genero",
                principalTable: "generos",
                principalColumn: "id_genero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
