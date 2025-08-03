using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Dtos.Programa;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class ProgramaService : IService<Programa, GetProgramaDto>
    {
        private readonly Database context;

        public ProgramaService(Database context)
        {
            this.context = context;
        }

        public async Task Delete(Programa entity)
        {
            try
            {
                context.Programa.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetProgramaDto>> FindAll()
        {
            try
            {
                return await context.Programa
                    .Select(programa => new GetProgramaDto
                    {
                        Id = programa.Id,
                        Nombre = programa.Nombre,
                        Descripcion = programa.Descripcion,
                        Duracion = programa.Duracion,
                        Facultad = programa.Facultad!.Nombre,
                        RutaImagen = programa.RutaImagen!

                    }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<GetProgramaDto>> FindPagination(int nPagina, int nMostrar)
        {

            try
            {
                return await context.Programa
                    .Select(programa => new GetProgramaDto
                    {
                        Id = programa.Id,
                        Nombre = programa.Nombre,
                        Descripcion = programa.Descripcion,
                        Duracion = programa.Duracion,
                        Facultad = programa.Facultad!.Nombre,
                        RutaImagen = programa.RutaImagen!

                    })
                    .OrderByDescending(programa => programa.Id)
                    .Skip((nPagina - 1) * nMostrar)
                    .Take(nMostrar)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string?> SaveImage(IFormFile archivo)
        {
            try
            {
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Programas");

                var ruta = Path.Combine(uploadsPath, archivo.FileName);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                return ruta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Programa?> FindById(int id)
        {
            try
            {
                return await context.Programa
                    .Include(p => p.Facultad)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetProgramaDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Programa
                    .Where(programa => programa.Id == id)
                    .Select(programa => new GetProgramaDto
                    {
                        Id = programa.Id,
                        Nombre = programa.Nombre,
                        Descripcion = programa.Descripcion,
                        Duracion = programa.Duracion,
                        Facultad = programa.Facultad!.Nombre,
                        RutaImagen = programa.RutaImagen!

                    }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save(Programa entity)
        {
            try
            {
                context.Programa.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Programa entity)
        {
            try
            {
                context.Programa.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
