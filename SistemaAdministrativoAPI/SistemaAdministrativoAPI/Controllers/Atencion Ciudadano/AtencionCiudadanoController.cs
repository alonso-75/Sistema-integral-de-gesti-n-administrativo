using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Atencion_Ciudadano;
using SistemaAdministrativoAPI.Servicios.Atencion_Ciudadano;

namespace SistemaAdministrativoAPI.Controllers.Atencion_Ciudadano
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtencionCiudadanoController : ControllerBase
    {
        private readonly AtencionCiudadanoService _ciudadanoService;

        public AtencionCiudadanoController(AtencionCiudadanoService atencionCiudadanoService)
        {
            _ciudadanoService = atencionCiudadanoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudadano>>> GetUsuarios()
        {
            return Ok(await _ciudadanoService.GetUsuariosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ciudadano>> GetUsuario(int id)
        {
            var usuario = await _ciudadanoService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpGet("buscar/{documento}")]
        public async Task<ActionResult<Ciudadano>> BuscarPorDocumento(string documento)
        {
            var usuario = await _ciudadanoService.BuscarPorDocumentoAsync(documento);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Ciudadano>> PostUsuario( Ciudadano ciudadano)
        {
            var createdUsuario = await _ciudadanoService.CreateUsuarioAsync(ciudadano);
            return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, createdUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Ciudadano ciudadano)
        {
            var updated = await _ciudadanoService.UpdateUsuarioAsync(id, ciudadano);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _ciudadanoService.DeleteUsuarioAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }


    }
}
