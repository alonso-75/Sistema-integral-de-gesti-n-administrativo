using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Usuario.DTOS;
using SistemaAdministrativoAPI.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace SistemaAdministrativoAPI.Servicios.Permisos
{
    public class PermisoService : IPermisoService
    {
        private readonly ApplicationDbContext _context;

        public PermisoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PermisoDTO>> ObtenerTodosAsync()
        {
            return await _context.Permisos
                .Select(p => new PermisoDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                })
                .ToListAsync();
        }

        public async Task<PermisoDTO?> ObtenerPorIdAsync(long id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null) return null;

            return new PermisoDTO
            {
                Id = permiso.Id,
                Nombre = permiso.Nombre
            };
        }

        public async Task<PermisoDTO> CrearAsync(CrearPermisoRequest request)
        {
            var permiso = new Permiso { Nombre = request.Nombre };
            _context.Permisos.Add(permiso);
            await _context.SaveChangesAsync();

            return new PermisoDTO
            {
                Id = permiso.Id,
                Nombre = permiso.Nombre
            };
        }
    }

}
