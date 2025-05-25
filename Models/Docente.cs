using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("docentes")]
    public class Docente 
    {
        [Key]
        [Column("id_docente")]
        public int Id { get; set; }

        [Column("cedula")]
        public required int Cedula { get; set; }

        [MaxLength(50)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [MaxLength(50)]
        [Column("apellido")]
        public required string Apellido { get; set; }


        [Column("edad")]
        public required int Edad { get; set; }

        [Column("id_genero")]
        [MaxLength(10)]
        public required int GeneroId { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [Column("email")]
        public required string Email { get; set; }

        [MaxLength(100)]
        [Column("contrasena")]
        public required string Contrasena { get; set; }

        [Column("id_rol")]
        public int RolId { get; set; }

        public Genero? Genero { get; set; }

        public Rol? Rol { get; set; }

        [JsonIgnore]
        public IEnumerable<Materia>? Materias { get; }
    }
}
