using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class RenombrandoColumnasEnEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_generos_genero",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "estudiantes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "estudiantes",
                newName: "id_genero");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_genero",
                table: "estudiantes",
                newName: "IX_estudiantes_id_genero");

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_generos_id_genero",
                table: "estudiantes",
                column: "id_genero",
                principalTable: "generos",
                principalColumn: "id_genero",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_generos_id_genero",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "estudiantes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id_genero",
                table: "estudiantes",
                newName: "genero");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_id_genero",
                table: "estudiantes",
                newName: "IX_estudiantes_genero");

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_generos_genero",
                table: "estudiantes",
                column: "genero",
                principalTable: "generos",
                principalColumn: "id_genero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
