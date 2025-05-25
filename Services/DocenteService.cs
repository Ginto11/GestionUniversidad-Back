using GestionUniversidad.Interfaces;
using GestionUniversidad.Db;
using Microsoft.Data.SqlClient;
using GestionUniversidad.Models;
using Microsoft.EntityFrameworkCore;
using GestionUniversidad.Dtos.Docente;
using GestionUniversidad.Dtos.Usuario;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionUniversidad.Services
{
    public class DocenteService : IService<Docente, GetDocenteDto>
    {

        private readonly Database context;
        private readonly Utilidades utilidades;

        public DocenteService(Database context, Utilidades utilidades)
        {
            this.context = context;
            this.utilidades = utilidades;
        }


        public async Task<IEnumerable<GetDocenteDto>> FindAll()
        {
            try
            {
                return await context.Docente
                .Select(docente => new GetDocenteDto
                {
                    Id = docente.Id,
                    Cedula = docente.Cedula,
                    Nombre = docente.Nombre,
                    Apellido = docente.Apellido,
                    Edad = docente.Edad,
                    Email = docente.Email,
                    Rol = docente.Rol!.NombreRol,
                    Genero = docente.Genero!.Nombre
                }).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Docente?> FindById(int id)
        {
            try
            {
                return await context.Docente
                .FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task Save(Docente entity)
        {
            try
            {
                context.Docente.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Docente entity)
        {
            try
            {
                context.Docente.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Delete(Docente entity)
        {
            try
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Docente?> Autenticar(UsuarioLoginDto usuarioLogin)
        {
            try
            {
                var contrasenaEncriptada = utilidades.Encriptar(usuarioLogin.Contrasena);

                return await context.Docente
                    .Include(d => d.Rol)
                    .Include(d => d.Genero)
                    .FirstOrDefaultAsync(d => d.Email == usuarioLogin.Email && d.Contrasena == contrasenaEncriptada);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetDocenteDto?> FindDtoById(int id)
        {
            try
            {
                return await context.Docente
                .Where(docente => docente.Id == id)
                .Select(docente => new GetDocenteDto
                {
                    Id = docente.Id,
                    Cedula = docente.Cedula,
                    Nombre = docente.Nombre,
                    Apellido = docente.Apellido,
                    Edad = docente.Edad,
                    Email = docente.Email,
                    Rol = docente.Rol!.NombreRol,
                    Genero = docente.Genero!.Nombre
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
