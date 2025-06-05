using SistemaAdministrativoAPI.Models.Usuario.DTOS;

namespace SistemaAdministrativoAPI.Servicios.Permisos
{
    public interface IPermisoService
    {
        Task<List<PermisoDTO>> ObtenerTodosAsync();
        Task<PermisoDTO?> ObtenerPorIdAsync(long id);
        Task<PermisoDTO> CrearAsync(CrearPermisoRequest request);
    }
}
