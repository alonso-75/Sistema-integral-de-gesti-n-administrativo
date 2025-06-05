using Microsoft.EntityFrameworkCore;
using SistemaAdministrativoAPI.Data;
using SistemaAdministrativoAPI.Models.Usuario;

namespace SistemaAdministrativoAPI.Servicios.Autenticacion
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Clave))
                return null;

            return _jwtService.GenerateToken(user);
        }

        public async Task<Usuario?> RegisterAsync(Usuario nuevoUsuario)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == nuevoUsuario.Email))
                return null;

            nuevoUsuario.Clave = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Clave);
            await _context.Usuarios.AddAsync(nuevoUsuario);
            await _context.SaveChangesAsync();
            return nuevoUsuario;
        }
    }
}
