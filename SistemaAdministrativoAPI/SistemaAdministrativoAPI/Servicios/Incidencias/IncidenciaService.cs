using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Incidencias;

namespace SistemaAdministrativoAPI.Servicios.Incidencias
{
    public class IncidenciaService
    {
        private readonly ApplicationDbContext _context;

        public IncidenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incidencia>> GetAllIncidencias()
        {
            return await _context.Incidencias.Include(i => i.Evidencias).ToListAsync();
        }

        public async Task<Incidencia?> GetIncidenciaById(int id)
        {
            return await _context.Incidencias.Include(i => i.Evidencias)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Incidencia> CreateIncidencia(Incidencia incidencia)
        {
            if (incidencia.Evidencias != null && incidencia.Evidencias.Any())
            {
                foreach (var evidencia in incidencia.Evidencias)
                {
                    _context.Evidencias.Add(evidencia);
                }
            }

            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();
            return incidencia;
        }

        public async Task<bool> UpdateIncidencia(int id, Incidencia incidencia)
        {
            if (id != incidencia.Id)
            {
                return false;
            }

            _context.Entry(incidencia).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return _context.Incidencias.Any(i => i.Id == id);
            }
        }

        public async Task<bool> DeleteIncidencia(int id)
        {
            var incidencia = await _context.Incidencias.Include(i => i.Evidencias).FirstOrDefaultAsync(i => i.Id == id);
            if (incidencia == null)
            {
                return false;
            }

            _context.Evidencias.RemoveRange(incidencia.Evidencias);
            _context.Incidencias.Remove(incidencia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

