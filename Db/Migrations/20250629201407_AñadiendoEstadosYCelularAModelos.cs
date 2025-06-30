using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionUniversidad.Db.Migrations
{
    /// <inheritdoc />
    public partial class AñadiendoEstadosYCelularAModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "celular",
                table: "estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "docentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "docentes",
                type: "bit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_actualizacion",
                table: "docentes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                table: "docentes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "celular",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "docentes");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "docentes");

            migrationBuilder.DropColumn(
                name: "fecha_actualizacion",
                table: "docentes");

            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                table: "docentes");
        }
    }
}
