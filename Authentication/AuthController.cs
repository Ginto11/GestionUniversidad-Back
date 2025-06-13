using GestionUniversidad.Dtos.Usuario;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Authentication
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EstudianteService estudianteService;
        private readonly DocenteService docenteService;
        private readonly AuthService authService;
        private readonly HttpContextAccessor httpContextAccessor;

        public AuthController(HttpContextAccessor httpContextAccessor, DocenteService docenteService, AuthService authService, EstudianteService estudianteService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.docenteService = docenteService;
            this.authService = authService;
            this.estudianteService = estudianteService;
        }

        [HttpPost]
        [Route("docentes/ingresar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> IngresarDocente(UsuarioLoginDto usuarioLoginDto)
        {

            try
            {
                var usuario = await docenteService.Autenticar(usuarioLoginDto);

                if (usuario == null)
                    return ManejoRespuestas.BadRequest("Credenciales incorrectas");

                string nombreCompleto = usuario.Nombre + " " + usuario.Apellido;
                string token = authService.GenerarToken(usuario.Id, nombreCompleto, usuario.Rol!.NombreRol);

                return Ok(new
                {
                    codigo = 200,
                    usuario = new
                    {
                        id = usuario.Id,
                        nombre = nombreCompleto,
                        token
                    },
                });

            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }


        }

        [HttpPost]
        [Route("estudiantes/ingresar")]
        public async Task<ActionResult> IngresarEstudiante(UsuarioLoginDto usuarioLoginDto)
        {
            try
            {
                var usuario = await estudianteService.Autenticar(usuarioLoginDto);

                if (usuario == null)
                    return ManejoRespuestas.BadRequest("Credenciales Incorrectas");

               
                string nombreCompleto = usuario.Nombre + " " + usuario.Apellido;
                string token = authService.GenerarToken(usuario.Id, nombreCompleto, usuario.Rol!.NombreRol);

                return Ok(new
                {
                    codigo = 200,
                    usuario = new
                    {
                        id = usuario.Id,
                        nombre = nombreCompleto,
                        rol = usuario.Rol!.NombreRol,
                        token
                    },
                });

            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }



        [HttpGet]
        [Route("validar_token")]
        public IActionResult ValidarToken([FromHeader(Name = "Authorization")] string? tokenHeader)
        {
            try
            {
                if (string.IsNullOrEmpty(tokenHeader) || !tokenHeader.StartsWith("Bearer "))
                    return ManejoRespuestas.ValidacionTokenException("Token no proporcionado o mal formado.");

                var token = tokenHeader.Substring("Bearer ".Length);
                var validacion = authService.ValidarToken(token);
                if (validacion == null)
                    return ManejoRespuestas.ValidacionTokenException("Token no valido.");

                return ManejoRespuestas.ValidacionTokenExitosa("Token valido.");

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }


        [HttpGet]
        [Route("decodificar_token")]
        public ActionResult ExtraerUsuario([FromHeader(Name = "Authorization")] string? token)
        {
            try
            {
                if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer "))
                    return ManejoRespuestas.ValidacionTokenException("Token no proporcionado o mal formado");

                var tokenJWT = token.Substring("Bearer ".Length);
                var data = authService.GetUsuarioFromToken(tokenJWT);

                return Ok(data);

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }




        /*[HttpGet]
        [Route("validar_token")]
        public IActionResult ValidarToken([FromHeader(Name = "Authorization")] string? authHeader)
        {
            try
            {
                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                    return Unauthorized("Token no proporcionado o mal formado.");

                string token = authHeader.Substring("Bearer ".Length).Trim();
                var validacion = authService.ValidarToken(token);

                if (validacion == null)
                    return Unauthorized("Token inválido.");

                return Ok("Token válido");
            } 
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno: " + ex.Message);
            }
        }*/
    }
}
