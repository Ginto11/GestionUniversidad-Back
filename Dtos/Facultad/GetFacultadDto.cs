using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionUniversidad.Dtos.Facultad
{
    [NotMapped]
    public class GetFacultadDto
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

    }
}
