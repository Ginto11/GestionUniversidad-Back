using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("matriculas")]
    public class Matricula
    {
        [Key]
        [Column("id_matricula")]
        public int Id { get; set; } 

        [Column("id_estudiante")]
        public required int EstudianteId { get; set; }


        [Column("semestre")]
        public required int Semestre { get; set; }

        [Column("fecha_matricula")]
        public required DateTime FechaMatricula { get; set; }

        [Column("estado_matricula")]
        public required int EstadoMatriculaId { get; set; }

        [Column("esta_paga")]
        public required bool EstaPaga { get; set; }

        [Column("costo_matricula")]
        [Precision(10, 2)]
        public decimal? CostoMatricula { get; set; }

        [JsonIgnore]
        public IEnumerable<InscribirMateria>? InscribirMateria { get; set; }

        [JsonIgnore]
        public EstadoMatricula? EstadoMatricula { get; set; }

        [JsonIgnore]
        public Estudiante? Estudiante { get; set; }
    
    }
}
