using FluorSalesApp.Models;
using FluorSalesApp.Service;
using FluorSalesApp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluorSalesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepController : ControllerBase
    {
        private readonly ISalesRepService _service;

        public SalesRepController(ISalesRepService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesRepresentative>>> GetAll([FromQuery] string? platform, [FromQuery] string? region)
        {
            var reps = await _service.GetAllAsync(platform, region);
            return Ok(reps);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rep = await _service.GetByIdAsync(id);
            if (rep == null) return NotFound();
            return Ok(rep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesRepresentative rep)
        {
            var created = await _service.CreateAsync(rep);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SalesRepresentative rep)
        {
            if (id != rep.Id) return BadRequest("ID mismatch");
            await _service.UpdateAsync(rep);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
