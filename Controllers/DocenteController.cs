using GestionUniversidad.Dtos.Docente;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("api/docentes")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly DocenteService docenteService;
        private readonly Utilidades utilidades;

        public DocenteController(DocenteService docenteService, Utilidades utilidades)
        {
            this.docenteService = docenteService;
            this.utilidades = utilidades;
        }

        //METODO QUE ME LISTA TODOS LOS DOCENTES
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetDocenteDto>> ListarDocentes()
        {
            try
            {
                var docentesDto = await docenteService.FindAll();

                return Ok(docentesDto);
            }
            catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        //METODO QUE ME BUSCA UN DOCENTE POR ID
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
                var docente = await docenteService.FindDtoById(id);

                if (docente == null)
                    return ManejoException.NotFound(id);

                return Ok(docente);

            } catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Crear(PostDocenteDto body)
        {
            try
            {
                var docenteCreado = new Docente
                {
                    Cedula = body.Cedula,
                    Nombre = body.Nombre,
                    Apellido = body.Apellido,
                    Edad = body.Edad,
                    GeneroId = body.GeneroId,
                    Email = body.Email,
                    Contrasena = utilidades.Encriptar(body.Contrasena),
                    RolId = body.RolId
                };

                await docenteService.Save(docenteCreado);

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
        public async Task<ActionResult> Actualizar(PutDocenteDto body, int id)
        {
            try
            {
                var docente = await docenteService.FindById(id);

                if (docente == null)
                    return ManejoException.NotFound(id);

                docente.Cedula = body.Cedula;
                docente.Nombre = body.Nombre!;
                docente.Apellido = body.Apellido!;
                docente.Edad = body.Edad;
                docente.Email = body.Email!;
                docente.RolId = body.RolId; 
                docente.GeneroId = body.GeneroId;

                await docenteService.Update(docente);

                return NoContent();

            }catch(Exception error)
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
                var docente = await docenteService.FindById(id);

                if (docente == null)
                    return ManejoException.NotFound(id);

                await docenteService.Delete(docente);

                return NoContent();

            } catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
            
        }



    }
}
