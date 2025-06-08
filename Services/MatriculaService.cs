using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Materia;
using GestionUniversidad.Dtos.Matricula;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class MatriculaService : IServiceMatricula 
    {

        private readonly Database context;

        public MatriculaService(Database context)
        {
            this.context = context;
        }

        public Task Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetMatriculaDto>> FindAll()
        {
            try
            {
                return await context.Matricula
                   .Select(matricula => new GetMatriculaDto
                   {
                       Id = matricula.Id,
                       Cedula = matricula.Estudiante!.Cedula,
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

        public async Task<IEnumerable<GetMatriculaDto>> FindAllByCC(int id)
        {
            try
            {
                return await context.Matricula
                   .Where(matricula =>  matricula.Estudiante!.Cedula == id)
                   .Select(matricula => new GetMatriculaDto
                   {
                       Id = matricula.Id,
                       Cedula = matricula.Estudiante!.Cedula,
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


        public async Task<GetMatriculaDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Matricula
                   .Where(matricula => matricula.Id == id)
                   .Select(matricula => new GetMatriculaDto
                   {
                       Id = matricula.Id,
                       Cedula = matricula.Estudiante!.Cedula,
                       Nombre = matricula.Estudiante.Nombre,
                       Apellido = matricula.Estudiante.Apellido,
                       Semestre = matricula.Semestre,
                       Email = matricula.Estudiante.Email,
                       EstadoMatricula = matricula.EstadoMatricula!.NombreEstado,
                       FechaMatricula = matricula.FechaMatricula,
                       CostoMatricula = matricula.CostoMatricula,
                       EstadoPago = matricula.EstaPaga == false ? "No pagada." : "Pagada"
                   }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Matricula?> FindById(int id)
        {
            try
            {
                return await context.Matricula.FirstOrDefaultAsync(matricula => matricula.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Pay(int id)
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC pagarMatricula @id_matricula;",
                    new SqlParameter("@id_matricula", id));

            }catch(SqlException){
                throw;
            }
        }

        public async Task Save(int id)
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC generandoMatricula @id_estudiante;",
                    new SqlParameter("@id_estudiante", id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
