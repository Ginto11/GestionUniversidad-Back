using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("estado_matricula")]
    public class EstadoMatricula
    {
        [Key]
        [Column("id_estado_matricula")]
        public int Id { get; set; }

        [Column("nombre_estado")]
        [MaxLength(20)]
        public required string NombreEstado { get; set; }

        [JsonIgnore]
        public IEnumerable<Matricula>? Matriculas { get; set; }

        
    }
}
