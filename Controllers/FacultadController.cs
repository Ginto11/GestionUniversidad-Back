using GestionUniversidad.Dtos.Facultad;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [ApiController]
    [Route("api/facultades")]
    public class FacultadController : ControllerBase
    {
        private readonly FacultadService facultadService;

        public FacultadController(FacultadService facultadService)
        {
            this.facultadService = facultadService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetFacultadDto>> ListarFacultades()
        {
            try
            {
                var facultades = await facultadService.FindAll();

                return Ok(facultades);

            }catch(Exception error)
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
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var facultad = await facultadService.FindDtoById(id);
                if (facultad == null)
                    return ManejoException.NotFound(id);

                return Ok(facultad);
            }
            catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Crear(PostFacultadDto facultadDto)
        {
            try
            {
                var facultad = new Facultad 
                { 
                    Nombre = facultadDto.Nombre,
                    Descripcion = facultadDto.Descripcion
                };

                await facultadService.Save(facultad);

                return Created();

            }catch(Exception error)
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
        public async Task<ActionResult> Actualizar(PutFacultadDto facultadDto, int id)
        {
            try
            {
                var facultad = await facultadService.FindById(id);

                if (facultad == null)
                    return ManejoException.NotFound(id);

                facultad.Nombre = facultadDto.Nombre;
                facultad.Descripcion = facultadDto.Descripcion;

                await facultadService.Update(facultad);

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
                var facultad = await facultadService.FindById(id);

                if (facultad == null)
                    return ManejoException.NotFound(id);

                await facultadService.Delete(facultad);

                return NoContent();



            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        } 



    }
}
