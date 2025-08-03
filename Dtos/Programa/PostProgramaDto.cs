using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Programa
{
    [NotMapped]
    public class PostProgramaDto
    {

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

        public required byte Duracion { get; set; }

        public required int FacultadId { get; set; }

        public required IFormFile Imagen { get; set; }
    }
}
