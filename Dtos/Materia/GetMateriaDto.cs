using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Materia
{
    [NotMapped]
    public class GetMateriaDto
    {
        public required int Id { get; set; }

        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }
        
        public int? HorasEstudio { get; set; }
        
        public required int Creditos { get; set; }

        public required decimal ValorCredito { get; set; }

        public decimal? CostoTotal { get; set; }

        public required string Modalidad { get; set; }
        
        public required string EstadoMateria { get; set; }

        public required string NombrePrograma { get; set; }

    }
}
