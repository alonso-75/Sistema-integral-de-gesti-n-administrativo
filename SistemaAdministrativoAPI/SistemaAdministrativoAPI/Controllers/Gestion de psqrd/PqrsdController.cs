using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd;
using SistemaAdministrativoAPI.Servicios;

namespace SistemaAdministrativoAPI.Controllers.Gestion_de_psqrd
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class PqrsdController : ControllerBase
    {
        private readonly IPqrsdService _service;

        public PqrsdController(IPqrsdService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pqrsd pqrsd)
        {
            var created = await _service.CreateAsync(pqrsd);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPost("completo")]
        public async Task<IActionResult> CrearConArchivos([FromBody] PqrsdDto dto)
        {
            var result = await _service.CreateWithArchivosAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Pqrsd pqrsd)
        {
            var updated = await _service.UpdateAsync(id, pqrsd);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }


    }
}
