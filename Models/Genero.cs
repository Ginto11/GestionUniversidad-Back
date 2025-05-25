using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("generos")]
    public class Genero
    {
        [Key]
        [Column("id_genero")]
        public int Id { get; set; }

        [MaxLength(20)]
        [Column("nombre_genero")]
        public required string Nombre { get; set; }

        [JsonIgnore]
        public IEnumerable<Docente>? Docentes { get; set; }

        [JsonIgnore]
        public IEnumerable<Estudiante>? Estudiantes { get; set; }
    }
}
