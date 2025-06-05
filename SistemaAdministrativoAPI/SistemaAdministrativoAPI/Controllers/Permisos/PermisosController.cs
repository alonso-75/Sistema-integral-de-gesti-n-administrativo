using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Usuario.DTOS;
using SistemaAdministrativoAPI.Servicios.Permisos;

namespace SistemaAdministrativoAPI.Controllers.Permisos
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : Controller
    {
        private readonly IPermisoService _permisoService;

        public PermisosController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var permisos = await _permisoService.ObtenerTodosAsync();
            return Ok(permisos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var permiso = await _permisoService.ObtenerPorIdAsync(id);
            if (permiso == null) return NotFound();
            return Ok(permiso);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearPermisoRequest request)
        {
            var nuevo = await _permisoService.CrearAsync(request);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
        }
    }
}
