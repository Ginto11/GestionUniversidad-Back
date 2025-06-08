using GestionUniversidad.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using GestionUniversidad.Dtos.InscribirMateria;

namespace GestionUniversidad.Services
{
    public class InscribirMateriaService
    {
        private readonly Database context;
        public InscribirMateriaService(Database context)
        {
            this.context = context;
        }

        public async Task<bool> RegisterMatter(int idMateria, int idMatricula)
        {
            try
            {
                var hayMateria = await context.Materia.FirstOrDefaultAsync(materia => materia.Id == idMateria);
                var hayMatricula = await context.Matricula.FirstOrDefaultAsync(matricula => matricula.Id == idMatricula);

                if(hayMateria != null && hayMatricula != null)
                {
                    await context.Database.ExecuteSqlRawAsync("EXEC inscripcionMateria @id_materia, @id_matricula;",
                        new SqlParameter("@id_materia", idMateria),
                        new SqlParameter("@id_matricula", idMatricula));

                    return true;

                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        } 

        public async Task<IEnumerable<GetInscribirMateria>> FindAll()
        {
            try
            {

                return await context.InscribirMateria
                    .Select(inscripcion => new GetInscribirMateria
                    {
                        Id = inscripcion.Id,
                        NombreEstudiante = inscripcion.Matricula!.Estudiante!.Nombre + " " + inscripcion.Matricula.Estudiante.Apellido,
                        CedulaEstudiante = inscripcion.Matricula.Estudiante.Cedula,
                        NombreDocente = inscripcion.Materia!.Docente!.Nombre + " " + inscripcion.Materia.Docente.Apellido,
                        CedulaDocente = inscripcion.Materia!.Docente!.Cedula,
                        IdMatricula = inscripcion.MatriculaId,
                        NombreMateria = inscripcion.Materia.Nombre,
                        Semestre = inscripcion.Matricula.Semestre,
                        Modalidad = inscripcion.Materia.Modalidad,
                        EstadoMatricula = inscripcion.Matricula.EstadoMatricula!.NombreEstado,
                        CostoInscripcion = inscripcion.Materia.CostoTotal
                    }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetInscribirMateria>> FindAllByCC(int cedula)
        {
            try
            {

                return await context.InscribirMateria
                    .Where(inscripcion => inscripcion.Matricula!.Estudiante!.Cedula == cedula)
                    .Select(inscripcion => new GetInscribirMateria
                    {
                        Id = inscripcion.Id,
                        NombreEstudiante = inscripcion.Matricula!.Estudiante!.Nombre + " " + inscripcion.Matricula.Estudiante.Apellido,
                        CedulaEstudiante = inscripcion.Matricula.Estudiante.Cedula,
                        NombreDocente = inscripcion.Materia!.Docente!.Nombre + " " + inscripcion.Materia.Docente.Apellido,
                        CedulaDocente = inscripcion.Materia!.Docente!.Cedula,
                        IdMatricula = inscripcion.MatriculaId,
                        NombreMateria = inscripcion.Materia.Nombre,
                        Semestre = inscripcion.Matricula.Semestre,
                        Modalidad = inscripcion.Materia.Modalidad,
                        EstadoMatricula = inscripcion.Matricula.EstadoMatricula!.NombreEstado,
                        CostoInscripcion = inscripcion.Materia.CostoTotal
                    }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetInscribirMateria?> FindDtoById(int id)
        {
            try
            {

                return await context.InscribirMateria
                    .Where(inscripcion => inscripcion.Id == id)
                    .Select(inscripcion => new GetInscribirMateria
                    {
                        Id = inscripcion.Id,
                        NombreEstudiante = inscripcion.Matricula!.Estudiante!.Nombre + " " + inscripcion.Matricula.Estudiante.Apellido,
                        CedulaEstudiante = inscripcion.Matricula.Estudiante.Cedula,
                        NombreDocente = inscripcion.Materia!.Docente!.Nombre + " " + inscripcion.Materia.Docente.Apellido,
                        CedulaDocente = inscripcion.Materia!.Docente!.Cedula,
                        IdMatricula = inscripcion.MatriculaId,
                        NombreMateria = inscripcion.Materia.Nombre,
                        Semestre = inscripcion.Matricula.Semestre,
                        Modalidad = inscripcion.Materia.Modalidad,
                        EstadoMatricula = inscripcion.Matricula.EstadoMatricula!.NombreEstado,
                        CostoInscripcion = inscripcion.Materia.CostoTotal
                    }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task FinishRegistration(int id)
        {
            try
            {
                await context.Database.ExecuteSqlRawAsync("EXEC finalizarIncripcion @id_matricula",
                    new SqlParameter("@id_matricula", id));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
