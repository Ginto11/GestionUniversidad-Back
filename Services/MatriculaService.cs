using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Matricula;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class MatriculaService : IService<Matricula, GetMatriculaDto>
    {

        private readonly Database context;

        public MatriculaService(Database context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GetMatriculaDto>> FindAll()
        {
            try
            {
                return await context.Matricula
                    .Include(matricula => matricula.Estudiante)
                    .Include(matricula => matricula.EstadoMatricula)
                    .Select(matricula => new GetMatriculaDto
                    {
                        Id = matricula.Id,
                        Cedula = matricula.Estudiante.cedula,
                        Nombre = matricula.Estudiante.Nombre,
                        Apellido = matricula.Estudiante.Apellido,
                        Semestre = matricula.Semestre,
                        Email = matricula.Estudiante.Email,
                        EstadoMatricula = matricula.EstadoMatricula!.NombreEstado,
                        FechaMatricula = matricula.FechaMatricula,
                        CostoMatricula = matricula.CostoMatricula,
                        EstadoPago = matricula.EstaPaga == false ? "No pagada." : "Pagada"
                    }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Matricula?> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMatriculaDto?> FindDtoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(Matricula entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Matricula entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Matricula entity)
        {
            throw new NotImplementedException();
        }
    }
}
