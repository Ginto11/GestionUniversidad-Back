using GestionUniversidad.Dtos.Docente;
using GestionUniversidad.Dtos.Estudiante;
using GestionUniversidad.Dtos.Facultad;
using GestionUniversidad.Dtos.Materia;
using GestionUniversidad.Dtos.Programa;
using GestionUniversidad.Dtos.Usuario;
using GestionUniversidad.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUniversidad.Db
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<Estudiante> Estudiante { get; set; }

        public DbSet<Docente> Docente { get; set; }

        public DbSet<EstadoMateria> EstadoMateria { get; set; }

        public DbSet<EstadoMatricula> EstadoMatricula { get; set; }

        public DbSet<Facultad> Facultad { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<InscribirMateria> InscribirMateria { get; set; }

        public DbSet<Materia> Materia { get; set; }

        public DbSet<Matricula> Matricula { get; set; }

        public DbSet<Programa> Programa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Docente>()
                .HasIndex(docente => docente.Cedula)
                .IsUnique();

            modelBuilder.Entity<Estudiante>()
                .HasIndex(estudiante => estudiante.Cedula)
                .IsUnique();

            modelBuilder.Entity<Matricula>()
                .Property(matricula => matricula.FechaMatricula)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Matricula>()
                .Property(matricula => matricula.EstaPaga)
                .HasDefaultValue(0);
        }
    }
}
