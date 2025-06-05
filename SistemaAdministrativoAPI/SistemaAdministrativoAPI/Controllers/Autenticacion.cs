using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Usuario;
using SistemaAdministrativoAPI.Models.Usuario.DTOS;
using SistemaAdministrativoAPI.Servicios.Autenticacion;

namespace SistemaAdministrativoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AutenticacionController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            if (token == null) return Unauthorized("Credenciales inválidas.");
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var usuario = new Usuario
            {
                UsuarioNombre = request.UsuarioNombre,
                Nombre = request.Nombre,
                Email = request.Email,
                Clave = request.Password, // ← Asegúrate de cifrar la clave antes de guardar
                RolId = request.RolId,
                Cargo = request.Cargo
            };

            var creado = await _authService.RegisterAsync(usuario);
            if (creado == null) return BadRequest("El usuario ya existe o hubo un error.");
            return Ok(new { creado.Id, creado.Email });
        }
    }
}
