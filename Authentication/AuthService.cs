using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionUniversidad.Authentication
{
    public class AuthService
    {
        private readonly IConfiguration config;
        private readonly HttpContextAccessor  httpContextAccessor;
        public AuthService(Database context, IConfiguration config, HttpContextAccessor httpContextAccessor)
        {
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }


        public string GenerarToken(int id, string nombreCompleto, string email, string rol)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UsuarioId", id.ToString()),
                new Claim(ClaimTypes.Name, nombreCompleto),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, rol)
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }

        public UsuarioLogueadoDto? GetUsuarioFromToken()
        {
            var identity = httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var usuarioClaims = identity.Claims;

                return new UsuarioLogueadoDto
                {
                    UsuarioId = usuarioClaims.FirstOrDefault(u => u.Type == "UsuarioId")?.Value,
                    NombreCompleto = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value,
                    Email = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value,
                    Rol = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }




    }
}
