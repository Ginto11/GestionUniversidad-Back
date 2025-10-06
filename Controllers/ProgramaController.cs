using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Dtos.Programa;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [ApiController]
    [Route("api/programas")]
    public class ProgramaController : ControllerBase
    {
        private readonly ProgramaService programaService;

        public ProgramaController(ProgramaService programaService)
        {
            this.programaService = programaService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetProgramaDto>> ListarProgramas()
        {
            try
            {
                var programasDto = await programaService.FindAll();

                return Ok(programasDto);

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{nPagina}/{nMostrar}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetProgramaDto>> ListarPaginacion(int nPagina, int nMostrar)
        {
            try
            {
                var programasDto = await programaService.FindPagination(nPagina, nMostrar);

                return Ok(programasDto);
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
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var programaDto = await programaService.FindDtoById(id);

                if (programaDto is null)
                    return ManejoRespuestas.NotFound(id);

                return Ok(programaDto);

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Crear([FromForm] PostProgramaDto body)
        {
            try
            {

                var imagen = body.Imagen;

                if(imagen == null || imagen.Length == 0)
                    return BadRequest("No se recibió la imagen.");

                var ruta = await programaService.SaveImage(imagen);

                var programa = new Programa
                {
                    Nombre = body.Nombre,
                    Descripcion = body.Descripcion,
                    Duracion = body.Duracion,
                    FacultadId = body.FacultadId,
                    RutaImagen = body.Imagen.FileName
                };

                await programaService.Save(programa);

                return Created();

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Actualizar([FromForm] PutProgramaDto body, int id)
        {
            try
            {
                var programa = await programaService.FindById(id);

                if (programa is null)
                    return ManejoRespuestas.NotFound(id);

                var imagen = body.Imagen;

                if (imagen == null || imagen.Length == 0)
                    return BadRequest("No se recibió la imagen.");

                await programaService.SaveImage(imagen);

                programa.Nombre = body.Nombre;
                programa.Descripcion = body.Descripcion;
                programa.Duracion = body.Duracion;
                programa.FacultadId = body.FacultadId;
                programa.RutaImagen = body.Imagen.FileName;

                await programaService.Update(programa);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                var programa = await programaService.FindById(id);

                if (programa is null)
                    return ManejoRespuestas.NotFound(id);

                var rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Programas");
                var rutaImagen = Path.Combine(rutaCarpeta, programa.RutaImagen!);

                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }


                await programaService.Delete(programa);

                return NoContent();
            }catch(Exception error)
            {
                return ManejoRespuestas.ServerError(error.Message);
            }
        }


    }
}
