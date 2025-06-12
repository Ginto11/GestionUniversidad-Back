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
        public AuthService(IConfiguration config, HttpContextAccessor httpContextAccessor)
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
