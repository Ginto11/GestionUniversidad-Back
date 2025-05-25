using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Facultad
{
    [NotMapped]
    public class PostFacultadDto
    {
        [MinLength(1, ErrorMessage = "El campo no puede estar vacio")]
        public required string Nombre { get; set; }

        [MinLength(1, ErrorMessage = "El campo no puede estar vacio")]
        public required string Descripcion { get; set; }
    }
}
