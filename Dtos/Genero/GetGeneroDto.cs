using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Genero
{
    [NotMapped]
    public class GetGeneroDto
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
    }
}
