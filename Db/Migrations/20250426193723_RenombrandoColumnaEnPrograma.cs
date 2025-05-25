using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class RenombrandoColumnaEnPrograma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programas_facultades_FacultadId",
                table: "programas");

            migrationBuilder.RenameColumn(
                name: "FacultadId",
                table: "programas",
                newName: "id_facultad");

            migrationBuilder.RenameIndex(
                name: "IX_programas_FacultadId",
                table: "programas",
                newName: "IX_programas_id_facultad");

            migrationBuilder.AlterColumn<int>(
                name: "id_facultad",
                table: "programas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_programas_facultades_id_facultad",
                table: "programas",
                column: "id_facultad",
                principalTable: "facultades",
                principalColumn: "id_facultad",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programas_facultades_id_facultad",
                table: "programas");

            migrationBuilder.RenameColumn(
                name: "id_facultad",
                table: "programas",
                newName: "FacultadId");

            migrationBuilder.RenameIndex(
                name: "IX_programas_id_facultad",
                table: "programas",
                newName: "IX_programas_FacultadId");

            migrationBuilder.AlterColumn<int>(
                name: "FacultadId",
                table: "programas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_programas_facultades_FacultadId",
                table: "programas",
                column: "FacultadId",
                principalTable: "facultades",
                principalColumn: "id_facultad");
        }
    }
}
