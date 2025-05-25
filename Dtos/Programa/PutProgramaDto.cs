using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Programa
{
    [NotMapped]
    public class PutProgramaDto
    {
        [MinLength(1, ErrorMessage = "El nombre no puede estar vacio.")]
        public required string Nombre { get; set; }

        [MinLength(1, ErrorMessage = "La descripcion no puede estar vacia.")]
        public required string Descripcion { get; set; }

        [Range(1, 10, ErrorMessage = "La duracion tiene que ser mayor a 0.")]
        public required byte Duracion { get; set; }

        [Range(1, 100, ErrorMessage = "La facultadId tiene que ser mayor a 0.")]
        public required int FacultadId { get; set; }
    }
}
