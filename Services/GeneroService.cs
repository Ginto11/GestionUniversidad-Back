using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Genero;
using GestionUniversidad.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class GeneroService
    {
        private readonly Database context;

        public GeneroService(Database context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<GetGeneroDto>> FindAll()
        {
            try
            {
                return await context.Genero
                    .Select(genero => new GetGeneroDto
                    {
                        Id = genero.Id,
                        Nombre = genero.Nombre
                    }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
