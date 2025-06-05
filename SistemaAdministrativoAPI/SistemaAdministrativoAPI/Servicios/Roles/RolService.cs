using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Usuario.DTOS;
using SistemaAdministrativoAPI.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace SistemaAdministrativoAPI.Servicios.Roles
{
    public class RolService : IRolService
    {
        private readonly ApplicationDbContext _context;

        public RolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolDTO>> ObtenerTodosAsync()
        {
            return await _context.Roles
                .Include(r => r.RolesPermisos)
                    .ThenInclude(rp => rp.Permiso)
                .Select(r => new RolDTO
                {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Permisos = r.RolesPermisos.Select(p => p.Permiso.Id).ToList()
                })
                .ToListAsync();
        }

        public async Task<RolDTO?> ObtenerPorIdAsync(long id)
        {
            var rol = await _context.Roles
                .Include(r => r.RolesPermisos)
                    .ThenInclude(rp => rp.Permiso)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rol == null) return null;

            return new RolDTO
            {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Permisos = rol.RolesPermisos.Select(p => p.Permiso.Id).ToList()
            };
        }

        public async Task<RolDTO> CrearRolAsync(CrearRolRequest request)
        {
            var rol = new Rol { Nombre = request.Nombre };
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            foreach (var permisoId in request.PermisosId)
            {
                _context.RolesPermisos.Add(new RolPermiso
                {
                    RolId = rol.Id,
                    PermisoId = permisoId
                });
            }

            await _context.SaveChangesAsync();

            return await ObtenerPorIdAsync(rol.Id) ?? throw new Exception("Error al crear rol.");
        }
    }
}
