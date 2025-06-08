using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.InscribirMateria
{
    [NotMapped]
    public class GetInscribirMateria
    {
        public required int Id { get; set; }

        public required string NombreEstudiante { get; set; }

        public required int CedulaEstudiante { get; set; }

        public required string NombreDocente { get; set; }

        public required int CedulaDocente { get; set; }

        public int? IdMatricula { get; set; }

        public required string NombreMateria { get; set; }

        public required int Semestre { get; set; }

        public required string Modalidad { get; set; }

        public required string EstadoMatricula { get; set; }

        public decimal? CostoInscripcion { get; set; }


    }
}
