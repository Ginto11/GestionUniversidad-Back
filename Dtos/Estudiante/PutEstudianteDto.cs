using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Estudiante
{
    [NotMapped]
    public class PutEstudianteDto
    {
        public required int Cedula { get; set; }

        [MinLength(1, ErrorMessage = "El campo nombre no puede estar vacio.")]
        public required string Nombre { get; set; }

        [MinLength(1, ErrorMessage = "El campo apellido no puede estar vacio.")]
        public required string Apellido { get; set; }

        [Range(1, 100, ErrorMessage = "La edad debe ser mayor a 0.")]
        public required int Edad { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Range(1, 10, ErrorMessage = "El generoId debe ser mayor a 0.")]
        public required int GeneroId { get; set; }

        [Range(1, 100, ErrorMessage = "El rolId debe ser mayor a 0.")]
        public required int RolId { get; set; }
    }
}
