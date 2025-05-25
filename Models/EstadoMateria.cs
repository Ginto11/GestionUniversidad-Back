using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("estado_materia")]
    public class EstadoMateria
    {
        [Key]
        [Column("id_estado_materia")]
        public int Id { get; set; }

        [MaxLength(20)]
        [Column("nombre_estado")]
        public required string NombreEstado { get; set; }

        [JsonIgnore]
        public IEnumerable<Materia>? Materias { get; set; }

    }
}
