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
        public AuthService(IConfiguration config)
        {
            this.config = config;
        }


        public string GenerarToken(int id, string nombreCompleto, string rol)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("IdUsuario", id.ToString()),
                new Claim(ClaimTypes.Name, nombreCompleto),
                new Claim(ClaimTypes.Role, rol)
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

            
        }

        public UsuarioLogueadoDto? GetUsuarioFromToken(string token)
        {

            var manejador = new JwtSecurityTokenHandler();

            if (!manejador.CanReadToken(token))
                return null;


            var usuarioClaims = manejador.ReadJwtToken(token).Claims;

            return new UsuarioLogueadoDto
            {
                Id = usuarioClaims.FirstOrDefault(u => u.Type == "IdUsuario")?.Value,
                NombreCompleto = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value,
                Rol = usuarioClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value
            };

        }


        public ClaimsPrincipal? RevisarToken(string token)
        {
            byte[] key = Encoding.UTF8.GetBytes(config["Jwt:Key"]!);
            var manejadorToken = new JwtSecurityTokenHandler();

            var parametrosToken = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                var principal = manejadorToken.ValidateToken(token, parametrosToken, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                if (jwtToken == null || jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Token Valido");

                return principal;
                
            }catch(Exception)
            {
                return null;
            }
        }








































        public ClaimsPrincipal? ValidarToken(string token)
        {
            byte[] bytesLlaveSecreta = Encoding.UTF8.GetBytes(config["Jwt:Key"]!);

            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(bytesLlaveSecreta),

                ValidateIssuer = false,
                ValidateAudience = false, 

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero 
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Aquí puedes revisar los claims si deseas
                var jwtToken = validatedToken as JwtSecurityToken;
                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Token inválido");

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
