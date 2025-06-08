using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("api/inscripciones")]
    [ApiController]
    public class InscribirMateriaController : ControllerBase
    {
        private readonly InscribirMateriaService inscribirMateriaService;
        public InscribirMateriaController(InscribirMateriaService inscribirMateriaService)
        {
            this.inscribirMateriaService = inscribirMateriaService;
        }

        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        [Route("inscribir_materia/{idMateria}/{idMatricula}")]
        public async Task<ActionResult> InscribirMateria(int idMateria, int idMatricula)
        {
            try
            {
                var isInscripcionExitosa = await inscribirMateriaService.RegisterMatter(idMateria, idMatricula);

                if (isInscripcionExitosa == true)
                {
                    return NoContent();
                }

                return ManejoException.BadRequest("Error al momento de inscribir materia");

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> ListarInscripciones()
        {
            try
            {
                var inscripciones = await inscribirMateriaService.FindAll();

                return Ok(inscripciones);

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
                var inscripcion = await inscribirMateriaService.FindDtoById(id);

                if (inscripcion == null)
                    return ManejoException.NotFound(id);

                return Ok(inscripcion);

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
                var inscripcion = await inscribirMateriaService.FindAllByCC(cedula);

                if (inscripcion == null)
                    return ManejoException.NotFound(cedula);

                return Ok(inscripcion);

            }
            catch (Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Estudiante")]
        [Route("finalizar_inscripcion/{id}")]
        public async Task<ActionResult> FinalizarInscripcion(int id)
        {
            try
            {
                var inscripcion = await inscribirMateriaService.FindDtoById(id);

                if (inscripcion == null)
                    return ManejoException.NotFound(id);

                await inscribirMateriaService.FinishRegistration(id);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }
    }
}
