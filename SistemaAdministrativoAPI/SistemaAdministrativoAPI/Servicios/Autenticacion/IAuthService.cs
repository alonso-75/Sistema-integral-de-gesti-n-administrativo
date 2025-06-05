using SistemaAdministrativoAPI.Models.Usuario;

namespace SistemaAdministrativoAPI.Servicios.Autenticacion
{
    public interface IAuthService
    {

        Task<string?> LoginAsync(string email, string password);
        Task<Usuario?> RegisterAsync(Usuario nuevoUsuario);
    }
}
