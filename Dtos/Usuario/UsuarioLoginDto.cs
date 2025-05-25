using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionUniversidad.Dtos.Usuario
{
    [NotMapped]
    public class UsuarioLoginDto
    {
        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(10, ErrorMessage = "La contraseña debe tener como minimo 10 caracteres.")]
        public required string Contrasena { get; set; }


    }
}
