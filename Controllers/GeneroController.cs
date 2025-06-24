using GestionUniversidad.Dtos.Genero;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [ApiController]
    [Authorize(Roles = "Administrador")]
    [Route("api/generos")]
    public class GeneroController : Controller
    {
        private readonly GeneroService generoService;

        public GeneroController(GeneroService generoService)
        {
            this.generoService = generoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGeneroDto>>> ListarGeneros()
        {
            try
            {
                var generosDto = await generoService.FindAll();
                return Ok(generosDto);
            }
            catch (Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

    }
}
