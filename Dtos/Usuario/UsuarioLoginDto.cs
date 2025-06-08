using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Usuario
{
    [NotMapped]
    public class UsuarioLoginDto
    {
        [EmailAddress]
        public required string Email { get; set; }

        public required string Contrasena { get; set; }


    }
}
