using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Matricula
{
    [NotMapped]
    public class GetMatriculaDto
    {
        public int Id { get; set; }

        public required int Cedula { get; set; }

        public required string Nombre { get; set; }

        public required string Apellido { get; set; }

        public required string Email { get; set; }

        public required int Semestre { get; set; }

        public required DateTime FechaMatricula { get; set; }

        public required string EstadoMatricula { get; set; }

        public required string EstadoPago { get; set; }

        public decimal? CostoMatricula { get; set; }

    }
}
