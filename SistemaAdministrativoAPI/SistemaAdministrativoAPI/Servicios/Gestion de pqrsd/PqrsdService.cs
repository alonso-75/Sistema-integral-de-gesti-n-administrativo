using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Archivos;
using SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd;

namespace SistemaAdministrativoAPI.Servicios.Gestion_de_pqrsd
{
    public class PqrsdService : IPqrsdService
    {
        private readonly ApplicationDbContext _context;

        public PqrsdService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pqrsd>> GetAllAsync() =>
            await _context.Pqrsds.Include(p => p.Archivos).ToListAsync();

        public async Task<Pqrsd?> GetByIdAsync(long id) =>
            await _context.Pqrsds.Include(p => p.Archivos).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Pqrsd> CreateAsync(Pqrsd pqrsd)
        {
            _context.Pqrsds.Add(pqrsd);
            await _context.SaveChangesAsync();
            return pqrsd;
        }

        public async Task<Pqrsd?> UpdateAsync(long id, Pqrsd updated)
        {
            var existing = await _context.Pqrsds.FindAsync(id);
            if (existing is null) return null;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var pqrsd = await _context.Pqrsds.FindAsync(id);
            if (pqrsd is null) return false;

            _context.Pqrsds.Remove(pqrsd);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Pqrsd> CreateWithArchivosAsync(PqrsdDto dto)
        {
            var pqrsd = new Pqrsd
            {
                Radicado = dto.Radicado,
                FechaRecibido = dto.FechaRecibido,
                Remitente = dto.Remitente,
                Asunto = dto.Asunto,
                Folios = dto.Folios,
                Razon = dto.Razon,
                RecibidoPor = dto.RecibidoPor,
                Responsable = dto.Responsable,
                FechaEntregaResponsable = dto.FechaEntregaResponsable,
                FechaVencimiento = dto.FechaVencimiento,
                FechaSalida = dto.FechaSalida,
                Estado = dto.Estado,
                DiasFaltantes = dto.DiasFaltantes,
                Cumplimiento = dto.Cumplimiento,
                Rp = dto.Rp,
                Observaciones = dto.Observaciones,
                Archivos = dto.Archivos.Select(a => new Archivo
                {
                    Link = a.Link,
                    Descripcion = a.Descripcion
                }).ToList()
            };

            _context.Pqrsds.Add(pqrsd);
            await _context.SaveChangesAsync();
            return pqrsd;
        }
    }
}
