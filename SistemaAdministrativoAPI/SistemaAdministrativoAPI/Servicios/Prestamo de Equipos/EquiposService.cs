using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Prestamos;

namespace SistemaAdministrativoAPI.Servicios.Prestamo_de_Equipos
{
    public class EquiposService
    {
        private readonly ApplicationDbContext _context;

        public EquiposService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipos>> GetAllEquiposAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<Equipos?> GetEquipoByIdAsync(long id)
        {
            return await _context.Equipos.FindAsync(id);
        }

        public async Task<Equipos> CreateEquipoAsync(Equipos equipo)
        {
            equipo.FechaCreacion = DateTime.UtcNow;
            equipo.FechaActualizacion = DateTime.UtcNow;
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }

        public async Task<bool> UpdateEquipoAsync(long id, Equipos equipo)
        {
            var existingEquipo = await _context.Equipos.FindAsync(id);
            if (existingEquipo == null) return false;

            existingEquipo.NombreEquipo = equipo.NombreEquipo;
            existingEquipo.DescripcionEquipo = equipo.DescripcionEquipo;
            existingEquipo.EstadoEquipo = equipo.EstadoEquipo;
            existingEquipo.FechaActualizacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEquipoAsync(long id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return false;

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

