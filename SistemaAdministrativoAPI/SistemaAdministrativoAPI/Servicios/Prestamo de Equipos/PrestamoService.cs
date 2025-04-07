using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Prestamos;
using System;

namespace SistemaAdministrativoAPI.Servicios.Prestamo_de_Equipos
{
    public class PrestamoService
    {
        private readonly ApplicationDbContext _context;

        public PrestamoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los préstamos
        public async Task<List<Prestamos_equipos>> GetAllPrestamosAsync()
        {
            return await _context.PrestamosEquipos.Include(p => p.Equipo).ToListAsync();
        }

        // Obtener un préstamo por ID
        public async Task<Prestamos_equipos?> GetPrestamoByIdAsync(long id)
        {
            return await _context.PrestamosEquipos.Include(p => p.Equipo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Crear un préstamo
        public async Task<Prestamos_equipos> CreatePrestamoAsync(Prestamos_equipos prestamo)
        {
            // Buscar el equipo asociado al préstamo
            var equipo = await _context.Equipos.FindAsync(prestamo.EquipoId);
            if (equipo == null || equipo.EstadoEquipo != "Disponible")
            {
                throw new InvalidOperationException("El equipo no está disponible para préstamo.");
            }

            // Cambiar el estado del equipo a "Prestado"
            equipo.EstadoEquipo = "Prestado";
            equipo.FechaActualizacion = DateTime.UtcNow;

            // Registrar el préstamo
            prestamo.FechaCreacion = DateTime.UtcNow;
            prestamo.FechaActualizacion = DateTime.UtcNow;

            _context.PrestamosEquipos.Add(prestamo);
            await _context.SaveChangesAsync();

            // Guardar los cambios en el equipo
            await _context.SaveChangesAsync();

            return prestamo;
        }

        // Actualizar un préstamo
        public async Task<bool> UpdatePrestamoAsync(Prestamos_equipos prestamo)
        {
            var existingPrestamo = await _context.PrestamosEquipos.FindAsync(prestamo.Id);
            if (existingPrestamo == null) return false;

            existingPrestamo.FechaDevolucion = prestamo.FechaDevolucion;
            existingPrestamo.EstadoPrestamo = prestamo.EstadoPrestamo;
            existingPrestamo.PrestadoA = prestamo.PrestadoA;
            existingPrestamo.ContactoPrestatario = prestamo.ContactoPrestatario;
            existingPrestamo.FechaActualizacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un préstamo
        public async Task<bool> DeletePrestamoAsync(long id)
        {
            var prestamo = await _context.PrestamosEquipos.FindAsync(id);
            if (prestamo == null) return false;

            _context.PrestamosEquipos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
