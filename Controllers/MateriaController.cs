using GestionUniversidad.Dtos.Materia;
using GestionUniversidad.Models;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Controllers
{
    [Route("api/materias")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaService materiaService;

        public MateriaController(MateriaService materiaService)
        {
            this.materiaService = materiaService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<GetMateriaDto>> ListarMaterias()
        {
            try
            {
                var materias = await materiaService.FindAll();
                return Ok(materias);

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var materia = await materiaService.FindDtoById(id);

                if (materia == null)
                    return ManejoException.NotFound(id);

                return Ok(materia);

            }catch(Exception error){

                return ManejoException.ServerError(error.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> Crear(PostMateriaDto materiaDto)
        {
            try
            {
                var materia = new Materia
                {
                    Nombre = materiaDto.Nombre,
                    Descripcion = materiaDto.Descripcion,   
                    Creditos = materiaDto.Creditos,
                    ValorCredito = materiaDto.ValorCredito,
                    DocenteId = materiaDto.DocenteId,
                    ProgramaId = materiaDto.ProgramaId,
                    Modalidad = materiaDto.Modalidad
                };

                await materiaService.Save(materia);

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
        public async Task<ActionResult> Actualizar(PutMateriaDto materiaDto, int id)
        {
            try
            {
                if (id != materiaDto.Id)
                    throw new Exception("El id de la url no coincide con el del body.");

                var materia = await materiaService.FindById(id);

                if (materia == null)
                    return ManejoException.NotFound(id);

                materia.Id = id;
                materia.Nombre = materiaDto.Nombre;
                materia.Descripcion = materiaDto.Descripcion;
                materia.ValorCredito = materiaDto.ValorCredito;
                materia.ProgramaId = materiaDto.ProgramaId;
                materia.DocenteId = materiaDto.DocenteId;
                materia.Modalidad = materiaDto.Modalidad;
                materia.EstadoMateriaId = materiaDto.EstadoMateriaId;
                materia.Creditos = materiaDto.Creditos;

                await materiaService.Update(materia);

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
                var materia = await materiaService.FindById(id);

                if (materia == null)
                    return ManejoException.NotFound(id);

                await materiaService.Delete(materia);

                return NoContent();

            }catch(Exception error)
            {
                return ManejoException.ServerError(error.Message);
            }
        }





    }
}
