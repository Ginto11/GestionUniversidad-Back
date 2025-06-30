using GestionUniversidad.Db;
using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Dtos.Usuario;
using GestionUniversidad.Interfaces;
using GestionUniversidad.Models;
using GestionUniversidad.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Services
{
    public class EstudianteService : IService<Estudiante, GetEstudianteDto>
    {
        private readonly Database context;
        private readonly Utilidades utilidades;
        public EstudianteService(Database context, Utilidades utilidades)
        {
            this.context = context;
            this.utilidades = utilidades;
        }

        public async Task Delete(Estudiante entity)
        {
            try
            {
                context.Estudiante.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetEstudianteDto>> FindAll()
        {

            try
            {
                return await context.Estudiante
                    .Select(estudiante => new GetEstudianteDto
                    {
                        Id = estudiante.Id,
                        Cedula = estudiante.Cedula,
                        Nombre = estudiante.Nombre,
                        Apellido = estudiante.Apellido,
                        Edad = estudiante.Edad,
                        Celular = estudiante.Celular,
                        Email = estudiante.Email,
                        Rol = estudiante.Rol!.NombreRol,
                        Genero = estudiante.Genero!.Nombre,
                        GeneroId = estudiante.GeneroId,
                        Estado = estudiante.Estado,
                        FechaActualizacion = estudiante.FechaActualizacion,
                        FechaCreacion = estudiante.FechaCreacion
                    })
                    .Where(estudiante => estudiante.Rol == "Estudiante")
                    .OrderByDescending(estudiante => estudiante.FechaActualizacion)
                    .ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetEstudianteDto>> FindPagination(int nPagina, int nMostrar)
        {

            try
            {
                return await context.Estudiante
                    .Select(estudiante => new GetEstudianteDto
                    {
                        Id = estudiante.Id,
                        Cedula = estudiante.Cedula,
                        Nombre = estudiante.Nombre,
                        Apellido = estudiante.Apellido,
                        Edad = estudiante.Edad,
                        Celular = estudiante.Celular,
                        Email = estudiante.Email,
                        Rol = estudiante.Rol!.NombreRol,
                        Genero = estudiante.Genero!.Nombre,
                        GeneroId = estudiante.GeneroId,
                        Estado = estudiante.Estado,
                        FechaActualizacion = estudiante.FechaActualizacion,
                        FechaCreacion = estudiante.FechaCreacion
                    })
                    .Where(estudiante => estudiante.Rol == "Estudiante")
                    .OrderByDescending(estudiante => estudiante.FechaActualizacion)
                    .Skip((nPagina -1) * nMostrar)
                    .Take(nMostrar)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task<Estudiante?> FindById(int id)
        {
            try
            {
                return context.Estudiante
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save(Estudiante entity)
        {
            try
            {
                context.Estudiante.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public async Task<bool> FindByEmail(string email)
        {
            try
            {
                var existsEmail = await context.Estudiante
                    .Where(estudiante => estudiante.Email == email)
                    .FirstOrDefaultAsync();

                if(existsEmail != null)
                    return true;

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Estudiante entity)
        {
            try
            {
                context.Estudiante.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Estudiante?> Autenticar(UsuarioLoginDto usuarioLoginDto)
        {
            try
            {
                var contrasenaEncriptada = utilidades.Encriptar(usuarioLoginDto.Contrasena);

                return await context.Estudiante
                    .Include(e => e.Rol)
                    .Include(e => e.Genero)
                    .FirstOrDefaultAsync(e => e.Email == usuarioLoginDto.Email && e.Contrasena == contrasenaEncriptada);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetEstudianteDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Estudiante
                    .Where(estudiante => estudiante.Id == id)
                    .Select(estudiante => new GetEstudianteDto
                    {
                        Id = estudiante.Id,
                        Cedula = estudiante.Cedula,
                        Nombre = estudiante.Nombre,
                        Apellido = estudiante.Apellido,
                        Edad = estudiante.Edad,
                        Celular = estudiante.Celular,
                        Email = estudiante.Email,
                        Rol = estudiante.Rol!.NombreRol,
                        Genero = estudiante.Genero!.Nombre,
                        GeneroId = estudiante.GeneroId,
                        Estado = estudiante.Estado,
                        FechaCreacion = estudiante.FechaCreacion,
                        FechaActualizacion = estudiante.FechaActualizacion
                    }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
