using GestionUniversidad.Authentication;
using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{nPagina}/{nMostrar}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetEstudianteDto>> ListarPaginacion(int nPagina, int nMostrar)
        {
            try
            {
                var estudiantesDto = await estudianteService.FindPagination(nPagina, nMostrar);

                return Ok(estudiantesDto);
            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
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
                    return ManejoRespuestas.Unauthorized();

                var estudianteDto = await estudianteService.FindDtoById(id);

                if (estudianteDto == null)
                    return ManejoRespuestas.NotFound(id);

                return Ok(estudianteDto);
            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("buscar/{cedula}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> BuscarPorCedula(int cedula)
        {

            try
            {

                if (!User.Identity!.IsAuthenticated)
                    return ManejoRespuestas.Unauthorized();

                var estudianteDto = await estudianteService.FindDtoByCedula(cedula);

                if (estudianteDto == null)
                    return ManejoRespuestas.NotFound(cedula);

                return Ok(estudianteDto);
            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
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
                var existsEmail = await estudianteService.FindByEmail(estudianteDto.Email);

                if (existsEmail)
                    return ManejoRespuestas.Conflict(estudianteDto.Email);

                var estudiante = new Estudiante
                {
                    Cedula = estudianteDto.Cedula,
                    Nombre = estudianteDto.Nombre,
                    Apellido = estudianteDto.Apellido,
                    Edad = estudianteDto.Edad,
                    Celular = estudianteDto.Celular,
                    Email = estudianteDto.Email,
                    Contrasena = utilidades.Encriptar(estudianteDto.Contrasena),
                    GeneroId = estudianteDto.GeneroId,
                    Estado = false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    RolId = 2
                };

                await estudianteService.Save(estudiante);

                return Created();

            }
            catch (SqlException error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize]
        public async Task<ActionResult> Actualizar(PutEstudianteDto estudianteDto, int id)
        {
            try
            {
                var estudiante = await estudianteService.FindById(id);

                if (estudiante == null)
                    return ManejoRespuestas.NotFound(id);

                estudiante.Cedula = estudianteDto.Cedula;
                estudiante.Nombre = estudianteDto.Nombre!;
                estudiante.Apellido = estudianteDto.Apellido!;
                estudiante.Edad = estudianteDto.Edad;
                estudiante.Celular = estudianteDto.Celular;
                estudiante.Email = estudianteDto.Email!;
                estudiante.GeneroId = estudianteDto.GeneroId;
                estudiante.FechaActualizacion = DateTime.Now;
                estudiante.Estado = estudianteDto.Estado;

                await estudianteService.Update(estudiante);

                return NoContent();
            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
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
                    return ManejoRespuestas.NotFound(id);

                if (estudiante.Estado == true)
                    return ManejoRespuestas.ConflictOfRelation("El estudiante no se puede eliminar, tiene matriculas asociadas.");

                await estudianteService.Delete(estudiante);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

    }
}
