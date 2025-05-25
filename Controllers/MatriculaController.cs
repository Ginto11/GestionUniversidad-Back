using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Http;
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

    }
}
