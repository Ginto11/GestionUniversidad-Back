using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("api/matriculas")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {

        private readonly MatriculaService matriculaService;

        public MatriculaController(MatriculaService matriculaService)
        {
            this.matriculaService = matriculaService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> ListarMatriculas()
        {
            try
            {
                var matriculas = await matriculaService.FindAll();

                return Ok(matriculas);

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        [Route("generar_al/{idEstudiante}")]
        public async Task<ActionResult> Crear(int idEstudiante)
        {
            try
            {
                await matriculaService.Save(idEstudiante);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        [Route("pagar/{id}")]
        public async Task<ActionResult> Pagar(int id)
        {
            try
            {
                var matricula = await matriculaService.FindById(id);

                if (matricula == null)
                    return ManejoException.NotFound(id);

                await matriculaService.Pay(id);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        [Route("{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var matricula = await matriculaService.FindDtoById(id);

                if (matricula == null)
                    return ManejoException.NotFound(id);

                return Ok(matricula);

            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Estudiante, Administrador")]
        [Route("cedula/{cedula}")]
        public async Task<ActionResult> BuscarPorCedula(int cedula)
        {
            try
            {
                var matricula = await matriculaService.FindAllByCC(cedula);

                if (!matricula.Any())
                    return NotFound(new
                    {
                        codigo = 404,
                        mensaje = $"No se encontro ninguna matricula con la cedula {cedula}."
                    });

                return Ok(matricula);

            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

    }
}
