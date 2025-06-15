using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionUniversidad.Models
{
    [Table("programas")]
    public class Programa
    {
        [Key]
        [Column("id_programa")]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [MaxLength(1000)]
        [Column("descripcion")]
        public required string Descripcion { get; set; }

        [Column("duracion")]
        public required byte Duracion { get; set; }

        [Column("id_facultad")]
        public required int FacultadId { get; set; }

        [Column("ruta_imagen")] 
        public string? RutaImagen { get; set; }

        [JsonIgnore]
        public IEnumerable<Materia>? Materias { get; set; }

        public Facultad? Facultad { get; set; }

    }
}
