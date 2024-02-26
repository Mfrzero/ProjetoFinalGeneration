using Microsoft.AspNetCore.Mvc;
using ProjetoFinalGeneration.Models;
using ProjetoFinalGeneration.Repository.Temas;

namespace ProjetoFinalGeneration.Controllers
{
    [ApiController]
    [Route("api/temas")]
    public class TemaController : ControllerBase
    {
        private readonly ITemaService _temaService;

        public TemaController(ITemaService temaService)
        {
            _temaService = temaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetTemas()
        {
            var temas = await _temaService.GetAllTemasAsync();
            return Ok(temas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetTemaById(int id)
        {
            var tema = await _temaService.GetTemaByIdAsync(id);
            if (tema == null)
                return NotFound();

            return Ok(tema);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTema(Tema tema)
        {
            await _temaService.CreateTemaAsync(tema);
            return CreatedAtAction(nameof(GetTemaById), new { id = tema.Id }, tema);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTema(int id, Tema tema)
        {
            if (id != tema.Id)
                return BadRequest();

            await _temaService.UpdateTemaAsync(tema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTema(int id)
        {
            await _temaService.DeleteTemaAsync(id);
            return NoContent();
        }
    }

}
