namespace SistemaAdministrativoAPI.Models.Usuario.DTOS
{
    public class RegisterRequest
    {
        public string UsuarioNombre { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public long RolId { get; set; }
        public string? Cargo { get; set; }
    }
}
