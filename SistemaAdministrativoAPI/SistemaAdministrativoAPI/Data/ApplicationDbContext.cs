using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Models.Atencion_Ciudadano;
using SistemaAdministrativoAPI.Models.Prestamos;

namespace SistemaAdministrativoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<Prestamos_equipos> PrestamosEquipos { get; set; }
        public DbSet<Equipos> Equipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamos_equipos>()
                .HasOne(p => p.Equipo)
                .WithMany()
                .HasForeignKey(p => p.EquipoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamos_equipos>()
                .ToTable(t => t.HasCheckConstraint("CK_EstadoPrestamo", "EstadoPrestamo IN ('Pendiente', 'En curso', 'Devuelto', 'Retrasado')"));

            // Restricción CHECK para Genero
            //modelBuilder.Entity<Ciudadano>()
            //    .HasCheckConstraint("CHK_Genero", "Genero IN ('Masculino', 'Femenino', 'Otro')");

            // Restricción CHECK para TipoAtencion
            //modelBuilder.Entity<Atencion>()
            //    .HasCheckConstraint("CHK_TipoAtencion", "TipoAtencion IN ('Consulta', 'Seguimiento', 'Otro')");

            // Relación entre Usuario y Atencion
            modelBuilder.Entity<Atencion>()
                .HasOne(a => a.Ciudadano)
                .WithMany(u => u.Atenciones)
                .HasForeignKey(a => a.CiudadanoId)
                .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar Usuario si tiene Atenciones
        }
    }
}
