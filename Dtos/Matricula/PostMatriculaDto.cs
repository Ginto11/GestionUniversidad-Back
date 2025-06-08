using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Matricula
{
    [NotMapped]
    public class PostMatriculaDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "El idMatricula debe ser mayor a 0.")]
        public required int IdMatricula { get; set; }

        [Range(1, 10, ErrorMessage = "El SemestreMatricula debe ser mayor a 0 y menor a 10.")]
        public required int SemestreMatricula { get; set; }
    }
}
