using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class ColocandoMatriculaIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscribir_materia_matriculas_id_matricula",
                table: "inscribir_materia");

            migrationBuilder.DropForeignKey(
                name: "FK_materias_estado_materia_id_estado_materia",
                table: "materias");

            migrationBuilder.AlterColumn<int>(
                name: "id_estado_materia",
                table: "materias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "horas_estudio",
                table: "materias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "costo_total",
                table: "materias",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "id_matricula",
                table: "inscribir_materia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_inscribir_materia_matriculas_id_matricula",
                table: "inscribir_materia",
                column: "id_matricula",
                principalTable: "matriculas",
                principalColumn: "id_matricula");

            migrationBuilder.AddForeignKey(
                name: "FK_materias_estado_materia_id_estado_materia",
                table: "materias",
                column: "id_estado_materia",
                principalTable: "estado_materia",
                principalColumn: "id_estado_materia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscribir_materia_matriculas_id_matricula",
                table: "inscribir_materia");

            migrationBuilder.DropForeignKey(
                name: "FK_materias_estado_materia_id_estado_materia",
                table: "materias");

            migrationBuilder.AlterColumn<int>(
                name: "id_estado_materia",
                table: "materias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "horas_estudio",
                table: "materias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "costo_total",
                table: "materias",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_matricula",
                table: "inscribir_materia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inscribir_materia_matriculas_id_matricula",
                table: "inscribir_materia",
                column: "id_matricula",
                principalTable: "matriculas",
                principalColumn: "id_matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_materias_estado_materia_id_estado_materia",
                table: "materias",
                column: "id_estado_materia",
                principalTable: "estado_materia",
                principalColumn: "id_estado_materia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
