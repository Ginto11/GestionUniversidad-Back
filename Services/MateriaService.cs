using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Materia;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using GestionUniversidad.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class MateriaService : IService<Materia, GetMateriaDto>
    {
        private readonly Database context;

        public MateriaService(Database context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GetMateriaDto>> FindAll()
        {
            try
            {
                return await context.Materia.Select(materia => new GetMateriaDto
                {
                    Id = materia.Id,
                    Nombre = materia.Nombre,
                    Descripcion = materia.Descripcion,
                    CostoTotal = materia.CostoTotal,
                    Creditos = materia.Creditos,
                    ValorCredito = materia.ValorCredito,
                    EstadoMateria = materia.EstadoMateria!.NombreEstado,
                    HorasEstudio = materia.HorasEstudio,
                    Modalidad = materia.Modalidad,
                    NombrePrograma = materia.Programa!.Nombre

                }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Materia?> FindById(int id)
        {
            try
            {
                return await context.Materia.FirstOrDefaultAsync(materia => materia.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetMateriaDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Materia
                    .Where(materia => materia.Id == id)
                    .Select(materia => new GetMateriaDto
                    {
                        Id = materia.Id,
                        Nombre = materia.Nombre,
                        Descripcion = materia.Descripcion,
                        CostoTotal = materia.CostoTotal,
                        Creditos = materia.Creditos,
                        ValorCredito = materia.ValorCredito,
                        EstadoMateria = materia.EstadoMateria!.NombreEstado,
                        HorasEstudio = materia.HorasEstudio,
                        Modalidad = materia.Modalidad,
                        NombrePrograma = materia.Programa!.Nombre
                    }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save(Materia entity)
        {
            try
            {
                await context.Database
                     .ExecuteSqlRawAsync("EXEC crearMateria @nombre, @creditos, @valor_credito, @modalidad, @descripcion, @id_docente, @id_programa;",
                         new SqlParameter("@nombre", entity.Nombre),
                         new SqlParameter("@creditos", entity.Creditos),
                         new SqlParameter("@valor_credito", entity.ValorCredito), 
                         new SqlParameter("@modalidad", entity.Modalidad),
                         new SqlParameter("@descripcion", entity.Descripcion),
                         new SqlParameter("@id_docente", entity.DocenteId),
                         new SqlParameter("@id_programa", entity.ProgramaId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Materia entity)
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC actualizarMateria @id_materia, @nombre, @creditos, @valor_credito, @modalidad, @descripcion, @id_estado_materia, @id_docente, @id_programa;",
                    new SqlParameter("@id_materia", entity.Id),
                    new SqlParameter("@nombre", entity.Nombre),
                    new SqlParameter("@creditos", entity.Creditos),
                    new SqlParameter("@valor_credito", entity.ValorCredito),
                    new SqlParameter("@modalidad", entity.Modalidad),
                    new SqlParameter("@descripcion", entity.Descripcion),
                    new SqlParameter("@id_estado_materia", entity.EstadoMateriaId),
                    new SqlParameter("@id_docente", entity.DocenteId),
                    new SqlParameter("@id_programa", entity.ProgramaId));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Delete(Materia entity)
        {
            try
            {
                context.Materia.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
