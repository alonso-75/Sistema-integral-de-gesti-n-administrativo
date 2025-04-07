using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Incidencias;
using SistemaAdministrativoAPI.Servicios.Incidencias;

namespace SistemaAdministrativoAPI.Controllers.Incidencias
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly IncidenciaService _incidenciaService;

        public IncidenciasController(IncidenciaService incidenciaService)
        {
            _incidenciaService = incidenciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidencias()
        {
            return Ok(await _incidenciaService.GetAllIncidencias());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Incidencia>> GetIncidencia(int id)
        {
            var incidencia = await _incidenciaService.GetIncidenciaById(id);
            if (incidencia == null)
            {
                return NotFound();
            }
            return incidencia;
        }

        [HttpPost]
        public async Task<ActionResult<Incidencia>> CreateIncidencia(Incidencia incidencia)
        {
            var newIncidencia = await _incidenciaService.CreateIncidencia(incidencia);
            return CreatedAtAction(nameof(GetIncidencia), new { id = newIncidencia.Id }, newIncidencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncidencia(int id, Incidencia incidencia)
        {
            var result = await _incidenciaService.UpdateIncidencia(id, incidencia);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(int id)
        {
            var result = await _incidenciaService.DeleteIncidencia(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
