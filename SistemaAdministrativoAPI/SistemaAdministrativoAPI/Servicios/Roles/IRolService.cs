using SistemaAdministrativoAPI.Models.Usuario.DTOS;

namespace SistemaAdministrativoAPI.Servicios.Roles
{
    public interface IRolService
    {
        Task<List<RolDTO>> ObtenerTodosAsync();
        Task<RolDTO?> ObtenerPorIdAsync(long id);
        Task<RolDTO> CrearRolAsync(CrearRolRequest request);
    }
}
