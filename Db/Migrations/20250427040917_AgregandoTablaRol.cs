using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoTablaRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_estado_matricula_nombre_estado",
                table: "estado_matricula");

            migrationBuilder.DropIndex(
                name: "IX_estado_materia_nombre_estado",
                table: "estado_materia");

            migrationBuilder.AddColumn<int>(
                name: "id_rol",
                table: "estudiantes",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_rol",
                table: "docentes",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id_rol);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_cedula",
                table: "estudiantes",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_id_rol",
                table: "estudiantes",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_docentes_id_rol",
                table: "docentes",
                column: "id_rol");

            migrationBuilder.AddForeignKey(
                name: "FK_docentes_roles_id_rol",
                table: "docentes",
                column: "id_rol",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_roles_id_rol",
                table: "estudiantes",
                column: "id_rol",
                principalTable: "roles",
                principalColumn: "id_rol",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_docentes_roles_id_rol",
                table: "docentes");

            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_roles_id_rol",
                table: "estudiantes");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_estudiantes_cedula",
                table: "estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_estudiantes_id_rol",
                table: "estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_docentes_id_rol",
                table: "docentes");

            migrationBuilder.DropColumn(
                name: "id_rol",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "id_rol",
                table: "docentes");

            migrationBuilder.CreateIndex(
                name: "IX_estado_matricula_nombre_estado",
                table: "estado_matricula",
                column: "nombre_estado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estado_materia_nombre_estado",
                table: "estado_materia",
                column: "nombre_estado",
                unique: true);
        }
    }
}
