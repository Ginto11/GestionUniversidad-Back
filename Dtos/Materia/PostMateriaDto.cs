using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Materia
{
    [NotMapped]
    public class PostMateriaDto
    {
        [MinLength(1, ErrorMessage = "El campo nombre no puede estar vacio.")]
        public required string Nombre { get; set; }

        [MinLength(1, ErrorMessage = "El campo descripcion no puede estar vacio.")]
        public required string Descripcion { get; set; }

        [Range(1, 10, ErrorMessage = "Los creditos deben ser mayores a 0.")]
        public required int Creditos { get; set; }

        [Range(1, 1000000, ErrorMessage = "El valor del credito debe ser mayor a 0.")]
        public required decimal ValorCredito { get; set; }
        
        [MinLength(1, ErrorMessage = "El campo modalidad no puede estar vacio.")]
        public required string Modalidad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El DocenteId debe ser mayor a 0.")]
        public required int DocenteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El DocenteId debe ser mayor a 0.")]
        public required int ProgramaId { get; set; }

    }
}
