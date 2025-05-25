using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Models
{
    [Table("materias")]
    public class Materia
    {
        [Key]
        [Column("id_materia")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(200)]
        public required string Nombre { get; set; }

        [Column("horas_estudio")]
        public int? HorasEstudio { get; set; }

        [Column("creditos")]
        public required int Creditos { get; set; }

        [Column("valor_credito")]
        [Precision(10, 2)]
        public required decimal ValorCredito { get; set; }

        [Column("costo_total")]
        [Precision(10, 2)]
        public decimal? CostoTotal { get; set; }

        [Column("modalidad")]
        [MaxLength(30)]
        public required string Modalidad { get; set; }

        [Column("descripcion")]
        [MaxLength(800)]
        public required string Descripcion { get; set; }

        [Column("id_estado_materia")]
        public int? EstadoMateriaId { get; set; }

        public EstadoMateria? EstadoMateria { get; set; }

        [Column("id_docente")]
        public int DocenteId { get; set; }

        public Docente? Docente { get; set; }

        [Column("id_programa")]
        public int ProgramaId { get; set; }

        public Programa? Programa { get; set; }


    }
}
