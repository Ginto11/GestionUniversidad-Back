using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudianteController : Controller
    {
        private readonly EstudianteService estudianteService;
        private readonly Utilidades utilidades;

        public EstudianteController(EstudianteService estudianteService, Utilidades utilidades)
        {
            this.utilidades = utilidades;
            this.estudianteService = estudianteService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetEstudianteDto>> ListarEstudiantes()
        {
            try
            {
                var estudiantesDto = await estudianteService.FindAll();

                return Ok(estudiantesDto);
            }
            catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {

                if (!User.Identity!.IsAuthenticated)
                    return ManejoException.Unauthorized();

                var estudianteDto = await estudianteService.FindDtoById(id);

                if (estudianteDto == null)
                    return ManejoException.NotFound(id);

                return Ok(estudianteDto);
            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Crear(PostEstudianteDto estudianteDto)
        {
            try
            {
                var estudiante = new Estudiante
                {
                    cedula = estudianteDto.Cedula,
                    Nombre = estudianteDto.Nombre,
                    Apellido = estudianteDto.Apellido,
                    Edad = estudianteDto.Edad,
                    Email = estudianteDto.Email,
                    Contrasena = utilidades.Encriptar(estudianteDto.Contrasena),
                    GeneroId = estudianteDto.GeneroId,
                    RolId = estudianteDto.RolId
                };

                await estudianteService.Save(estudiante);

                return Created();
            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Actualizar(PutEstudianteDto estudianteDto, int id)
        {
            try
            {
                var estudiante = await estudianteService.FindById(id);

                if (estudiante == null)
                    return ManejoException.NotFound(id);

                estudiante.cedula = estudianteDto.Cedula;
                estudiante.Nombre = estudianteDto.Nombre!;
                estudiante.Apellido = estudianteDto.Apellido!;
                estudiante.Edad = estudianteDto.Edad;
                estudiante.Email = estudianteDto.Email!;
                estudiante.RolId = estudianteDto.RolId;
                estudiante.GeneroId = estudianteDto.GeneroId;

                await estudianteService.Update(estudiante);

                return NoContent();
            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var estudiante = await estudianteService.FindById(id);

                if (estudiante == null)
                    return ManejoException.NotFound(id);

                await estudianteService.Delete(estudiante);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

    }
}
