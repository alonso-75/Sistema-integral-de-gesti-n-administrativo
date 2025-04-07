using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Prestamos;
using SistemaAdministrativoAPI.Servicios.Prestamo_de_Equipos;

namespace SistemaAdministrativoAPI.Controllers.Prestamo_de_Equipos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        // GET: api/prestamo
        [HttpGet]
        public async Task<IActionResult> GetAllPrestamos()
        {
            var prestamos = await _prestamoService.GetAllPrestamosAsync();
            return Ok(prestamos);
        }

        // GET: api/prestamo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrestamoById(long id)
        {
            var prestamo = await _prestamoService.GetPrestamoByIdAsync(id);
            if (prestamo == null) return NotFound();
            return Ok(prestamo);
        }

        // POST: api/prestamo
        [HttpPost]
        public async Task<IActionResult> CreatePrestamo([FromBody] Prestamos_equipos prestamo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var nuevoPrestamo = await _prestamoService.CreatePrestamoAsync(prestamo);
            return CreatedAtAction(nameof(GetPrestamoById), new { id = nuevoPrestamo.Id }, nuevoPrestamo);
        }

        // PUT: api/prestamo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrestamo(long id, [FromBody] Prestamos_equipos prestamo)
        {
            if (id != prestamo.Id || !ModelState.IsValid) return BadRequest();

            var updated = await _prestamoService.UpdatePrestamoAsync(prestamo);
            if (!updated) return NotFound();

            return NoContent();
        }

        // DELETE: api/prestamo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(long id)
        {
            var deleted = await _prestamoService.DeletePrestamoAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
