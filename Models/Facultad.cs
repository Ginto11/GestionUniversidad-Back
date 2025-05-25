using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Models
{
    [Table("facultades")]
    public class Facultad
    {
        [Key]
        [Column("id_facultad")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [MaxLength(1000)]
        [Column("descripcion")]
        public required string Descripcion { get; set; }

        public IEnumerable<Programa>? Programas { get; set; }

    }
}
