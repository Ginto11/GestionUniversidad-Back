using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Facultad;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class FacultadService : IService<Facultad, GetFacultadDto>
    {
        private readonly Database context;

        public FacultadService(Database context)
        {
            this.context = context;
        }

        public async Task Delete(Facultad entity)
        {
            try
            {
                context.Facultad.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetFacultadDto>> FindAll()
        {
            try
            {
                return await context.Facultad.Select(facultad => new GetFacultadDto
                {
                    Id = facultad.Id,
                    Nombre = facultad.Nombre,
                    Descripcion = facultad.Descripcion

                }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Facultad?> FindById(int id)
        {
            try
            {
                return await context.Facultad
                    .FirstOrDefaultAsync(facultad => facultad.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        } 

        public async Task<GetFacultadDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Facultad
                .Where(f => f.Id == id)
                .Select(facultad => new GetFacultadDto
                {
                    Id = facultad.Id,
                    Nombre = facultad.Nombre,
                    Descripcion = facultad.Descripcion
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save(Facultad entity)
        {
            try
            {
                context.Facultad.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Facultad entity)
        {
            try
            {
                context.Facultad.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
