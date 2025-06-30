using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Models
{
    [Table("estudiantes")]
    public class Estudiante
    {
        [Key]
        [Column("id_estudiante")]
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

        [Column("celular")]
        public string? Celular { get; set; }

        [Column("id_genero")]
        [MaxLength(10)]
        public required  int GeneroId { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [Column("email")]
        public required string Email { get; set; }

        [MaxLength(100)]
        [Column("contrasena")]
        public required string Contrasena { get; set; }

        [Column("fecha_creacion")]
        public required DateTime FechaCreacion { get; set; }
        
        [Column("fecha_actualizacion")]
        public required DateTime FechaActualizacion { get; set; }

        [Column("estado")]
        public required bool Estado { get; set; }

        [Column("id_rol")]
        public int RolId { get; set; }

        public Rol? Rol { get; set; }
        public Genero? Genero { get; set; }

    }
}
