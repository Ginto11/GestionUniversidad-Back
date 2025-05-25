using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablas : Migration
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
                name: "matriculas",
                columns: table => new
                {
                    id_matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estudiante = table.Column<int>(type: "int", nullable: false),
                    semestre = table.Column<int>(type: "int", nullable: false),
                    fecha_matricula = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    esta_paga = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    costo_matricula = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas", x => x.id_matricula);
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
                    FacultadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programas", x => x.id_programa);
                    table.ForeignKey(
                        name: "FK_programas_facultades_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "facultades",
                        principalColumn: "id_facultad");
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
                    genero = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_docentes", x => x.id_docente);
                    table.ForeignKey(
                        name: "FK_docentes_generos_genero",
                        column: x => x.genero,
                        principalTable: "generos",
                        principalColumn: "id_genero",
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
                    genero = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.id_estudiante);
                    table.ForeignKey(
                        name: "FK_estudiantes_generos_genero",
                        column: x => x.genero,
                        principalTable: "generos",
                        principalColumn: "id_genero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    id_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    horas_estudio = table.Column<byte>(type: "tinyint", nullable: false),
                    creditos = table.Column<byte>(type: "tinyint", nullable: false),
                    valor_credito = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    costo_total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    modalidad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    id_estado_materia = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "id_estado_materia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_materias_programas_id_programa",
                        column: x => x.id_programa,
                        principalTable: "programas",
                        principalColumn: "id_programa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscribir_materia",
                columns: table => new
                {
                    id_inscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_materia = table.Column<int>(type: "int", nullable: false),
                    id_matricula = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "id_matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_docentes_cedula",
                table: "docentes",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_docentes_genero",
                table: "docentes",
                column: "genero");

            migrationBuilder.CreateIndex(
                name: "IX_estado_materia_nombre_estado",
                table: "estado_materia",
                column: "nombre_estado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estado_matricula_nombre_estado",
                table: "estado_matricula",
                column: "nombre_estado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_genero",
                table: "estudiantes",
                column: "genero");

            migrationBuilder.CreateIndex(
                name: "IX_facultades_nombre",
                table: "facultades",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generos_nombre_genero",
                table: "generos",
                column: "nombre_genero",
                unique: true);

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
                name: "IX_programas_FacultadId",
                table: "programas",
                column: "FacultadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estado_matricula");

            migrationBuilder.DropTable(
                name: "estudiantes");

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
                name: "generos");

            migrationBuilder.DropTable(
                name: "facultades");
        }
    }
}
