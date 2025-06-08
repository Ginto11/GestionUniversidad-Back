using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class Creacion_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estado_materia",
                columns: table => new
                {
                    id_estado_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_materia", x => x.id_estado_materia);
                });

            migrationBuilder.CreateTable(
                name: "estado_matricula",
                columns: table => new
                {
                    id_estado_matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_matricula", x => x.id_estado_matricula);
                });

            migrationBuilder.CreateTable(
                name: "facultades",
                columns: table => new
                {
                    id_facultad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultades", x => x.id_facultad);
                });

            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.id_genero);
                });

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

            migrationBuilder.CreateTable(
                name: "programas",
                columns: table => new
                {
                    id_programa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    duracion = table.Column<byte>(type: "tinyint", nullable: false),
                    id_facultad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programas", x => x.id_programa);
                    table.ForeignKey(
                        name: "FK_programas_facultades_id_facultad",
                        column: x => x.id_facultad,
                        principalTable: "facultades",
                        principalColumn: "id_facultad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "docentes",
                columns: table => new
                {
                    id_docente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    id_genero = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.id_docente);
                    table.ForeignKey(
                        name: "FK_docentes_generos_id_genero",
                        column: x => x.id_genero,
                        principalTable: "generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_docentes_roles_id_rol",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    id_estudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    id_genero = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.id_estudiante);
                    table.ForeignKey(
                        name: "FK_estudiantes_generos_id_genero",
                        column: x => x.id_genero,
                        principalTable: "generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_estudiantes_roles_id_rol",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    horas_estudio = table.Column<int>(type: "int", nullable: true),
                    creditos = table.Column<int>(type: "int", nullable: false),
                    valor_credito = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    costo_total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    modalidad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    id_estado_materia = table.Column<int>(type: "int", nullable: true),
                    id_docente = table.Column<int>(type: "int", nullable: false),
                    id_programa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.id_materia);
                    table.ForeignKey(
                        name: "FK_materias_docentes_id_docente",
                        column: x => x.id_docente,
                        principalTable: "docentes",
                        principalColumn: "id_docente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_materias_estado_materia_id_estado_materia",
                        column: x => x.id_estado_materia,
                        principalTable: "estado_materia",
                        principalColumn: "id_estado_materia");
                    table.ForeignKey(
                        name: "FK_materias_programas_id_programa",
                        column: x => x.id_programa,
                        principalTable: "programas",
                        principalColumn: "id_programa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matriculas",
                columns: table => new
                {
                    id_matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estudiante = table.Column<int>(type: "int", nullable: false),
                    semestre = table.Column<int>(type: "int", nullable: false),
                    fecha_matricula = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    estado_matricula = table.Column<int>(type: "int", nullable: false),
                    esta_paga = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    costo_matricula = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas", x => x.id_matricula);
                    table.ForeignKey(
                        name: "FK_matriculas_estado_matricula_estado_matricula",
                        column: x => x.estado_matricula,
                        principalTable: "estado_matricula",
                        principalColumn: "id_estado_matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matriculas_estudiantes_id_estudiante",
                        column: x => x.id_estudiante,
                        principalTable: "estudiantes",
                        principalColumn: "id_estudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscribir_materia",
                columns: table => new
                {
                    id_inscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_materia = table.Column<int>(type: "int", nullable: false),
                    id_matricula = table.Column<int>(type: "int", nullable: true),
                    costo_inscripcion = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscribir_materia", x => x.id_inscripcion);
                    table.ForeignKey(
                        name: "FK_inscribir_materia_materias_id_materia",
                        column: x => x.id_materia,
                        principalTable: "materias",
                        principalColumn: "id_materia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscribir_materia_matriculas_id_matricula",
                        column: x => x.id_matricula,
                        principalTable: "matriculas",
                        principalColumn: "id_matricula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_docentes_cedula",
                table: "docentes",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_docentes_id_genero",
                table: "docentes",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_docentes_id_rol",
                table: "docentes",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_cedula",
                table: "estudiantes",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_id_genero",
                table: "estudiantes",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_id_rol",
                table: "estudiantes",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_inscribir_materia_id_materia",
                table: "inscribir_materia",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_inscribir_materia_id_matricula",
                table: "inscribir_materia",
                column: "id_matricula");

            migrationBuilder.CreateIndex(
                name: "IX_materias_id_docente",
                table: "materias",
                column: "id_docente");

            migrationBuilder.CreateIndex(
                name: "IX_materias_id_estado_materia",
                table: "materias",
                column: "id_estado_materia");

            migrationBuilder.CreateIndex(
                name: "IX_materias_id_programa",
                table: "materias",
                column: "id_programa");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_estado_matricula",
                table: "matriculas",
                column: "estado_matricula");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_id_estudiante",
                table: "matriculas",
                column: "id_estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_programas_id_facultad",
                table: "programas",
                column: "id_facultad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inscribir_materia");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "matriculas");

            migrationBuilder.DropTable(
                name: "docentes");

            migrationBuilder.DropTable(
                name: "estado_materia");

            migrationBuilder.DropTable(
                name: "programas");

            migrationBuilder.DropTable(
                name: "estado_matricula");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "facultades");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
