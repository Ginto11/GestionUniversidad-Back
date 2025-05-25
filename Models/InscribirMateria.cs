using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Models
{
    [Table("inscribir_materia")]
    public class InscribirMateria
    {
        [Key]
        [Column("id_inscripcion")]
        public int Id { get; set; }

        [Column("id_materia")]
        public required int MateriaId { get; set; }

        [Column("id_matricula")]
        public int? MatriculaId { get; set; }

        [Precision(10, 2)]
        [Column("costo_inscripcion")]
        public required decimal CostoInscripcion { get; set; }

        public Materia? Materia { get; set; }

        public Matricula? Matricula { get; set; }

    }
}
