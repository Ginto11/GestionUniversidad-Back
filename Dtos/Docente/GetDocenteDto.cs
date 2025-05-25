using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Docente
{
    [NotMapped]
    public class GetDocenteDto
    {
        public required int Id { get; set; }
        public required int Cedula { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required int Edad { get; set; }
        public required string Email { get; set; }
        public required string Genero { get; set; }
        public required string Rol { get; set; }

    }
}
