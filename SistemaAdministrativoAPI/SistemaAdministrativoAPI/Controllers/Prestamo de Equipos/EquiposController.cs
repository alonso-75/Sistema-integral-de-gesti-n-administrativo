using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Prestamos;
using SistemaAdministrativoAPI.Servicios.Prestamo_de_Equipos;

namespace SistemaAdministrativoAPI.Controllers.Prestamo_de_Equipos
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly EquiposService _equiposService;

        public EquiposController(EquiposService equiposService)
        {
            _equiposService = equiposService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipos>>> GetAll()
        {
            return Ok(await _equiposService.GetAllEquiposAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipos>> GetById(long id)
        {
            var equipo = await _equiposService.GetEquipoByIdAsync(id);
            if (equipo == null) return NotFound();
            return Ok(equipo);
        }

        [HttpPost]
        public async Task<ActionResult<Equipos>> Create([FromBody] Equipos equipo)
        {
            var nuevoEquipo = await _equiposService.CreateEquipoAsync(equipo);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEquipo.Id }, nuevoEquipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Equipos equipo)
        {
            var actualizado = await _equiposService.UpdateEquipoAsync(id, equipo);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var eliminado = await _equiposService.DeleteEquipoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
