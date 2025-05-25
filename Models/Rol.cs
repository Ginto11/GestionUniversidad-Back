using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("id_rol")]
        public int Id { get; set; }

        [Column("nombre_rol")]
        public required string NombreRol { get; set; }

        [JsonIgnore]
        public IEnumerable<Estudiante>? Estudiantes { get; set; }

        [JsonIgnore]
        public IEnumerable<Docente>? Docentes { get; set; }
    }
}
