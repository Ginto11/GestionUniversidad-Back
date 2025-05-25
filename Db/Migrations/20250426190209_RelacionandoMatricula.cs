using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estado_matricula",
                table: "matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_estado_matricula",
                table: "matriculas",
                column: "estado_matricula");

            migrationBuilder.AddForeignKey(
                name: "FK_matriculas_estado_matricula_estado_matricula",
                table: "matriculas",
                column: "estado_matricula",
                principalTable: "estado_matricula",
                principalColumn: "id_estado_matricula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_matriculas_estado_matricula_estado_matricula",
                table: "matriculas");

            migrationBuilder.DropIndex(
                name: "IX_matriculas_estado_matricula",
                table: "matriculas");

            migrationBuilder.DropColumn(
                name: "estado_matricula",
                table: "matriculas");
        }
    }
}
