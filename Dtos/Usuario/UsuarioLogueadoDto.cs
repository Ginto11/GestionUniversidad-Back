using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Usuario
{
    [NotMapped]
    public class UsuarioLogueadoDto
    {
        public string? UsuarioId { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Email { get; set; }

        public string? Rol { get; set; }
    }
}
