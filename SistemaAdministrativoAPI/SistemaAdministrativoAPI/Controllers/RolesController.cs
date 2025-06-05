using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Usuario.DTOS;
using SistemaAdministrativoAPI.Servicios.Roles;

namespace SistemaAdministrativoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var roles = await _rolService.ObtenerTodosAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var rol = await _rolService.ObtenerPorIdAsync(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] CrearRolRequest request)
        {
            var nuevoRol = await _rolService.CrearRolAsync(request);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoRol.Id }, nuevoRol);
        }
    }

 }
