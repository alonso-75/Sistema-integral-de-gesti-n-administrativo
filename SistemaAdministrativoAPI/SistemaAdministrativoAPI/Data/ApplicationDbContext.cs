using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Models.Archivos;
using SistemaAdministrativoAPI.Models.Atencion_Ciudadano;
using SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd;
using SistemaAdministrativoAPI.Models.Incidencias;
using SistemaAdministrativoAPI.Models.Prestamos;
using SistemaAdministrativoAPI.Models.Usuario;

namespace SistemaAdministrativoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<Prestamos_equipos> PrestamosEquipos { get; set; }
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pqrsd> Pqrsds { get; set; }
        public DbSet<Archivo> Archivos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prestamos_equipos>()
                .HasOne(p => p.Equipo)
                .WithMany()
                .HasForeignKey(p => p.EquipoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamos_equipos>()
                .ToTable(t => t.HasCheckConstraint("CK_EstadoPrestamo", "EstadoPrestamo IN ('Pendiente', 'En curso', 'Devuelto', 'Retrasado')"));

            // Clave compuesta para RolPermiso
            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolesPermisos)
                .HasForeignKey(rp => rp.RolId);

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolesPermisos)
                .HasForeignKey(rp => rp.PermisoId);

            // Usuario -> Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // RolPermiso -> Rol
            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolesPermisos)
                .HasForeignKey(rp => rp.RolId);

            // RolPermiso -> Permiso
            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolesPermisos)
                .HasForeignKey(rp => rp.PermisoId);

            //relacion entre archivos y psqrsd
            modelBuilder.Entity<Archivo>()
           .HasOne(a => a.Pqrsd)
           .WithMany(p => p.Archivos)
           .HasForeignKey(a => a.PqrsdId)
           .OnDelete(DeleteBehavior.Cascade);

            // Restricción CHECK para Genero
            //modelBuilder.Entity<Ciudadano>()
            //    .HasCheckConstraint("CHK_Genero", "Genero IN ('Masculino', 'Femenino', 'Otro')");

            // Restricción CHECK para TipoAtencion
            //modelBuilder.Entity<Atencion>()
            //    .HasCheckConstraint("CHK_TipoAtencion", "TipoAtencion IN ('Consulta', 'Seguimiento', 'Otro')");

            // Relación entre Usuario y Atencion
            //modelBuilder.Entity<Atencion>()
            //    .HasOne(a => a.Ciudadano)
            //    .WithMany(u => u.Atenciones)
            //    .HasForeignKey(a => a.CiudadanoId)
            //    .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar Usuario si tiene Atenciones
        }
    }
}
