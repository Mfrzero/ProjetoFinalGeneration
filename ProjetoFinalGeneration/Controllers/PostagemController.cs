using Microsoft.AspNetCore.Mvc;
using ProjetoFinalGeneration.Models;
using ProjetoFinalGeneration.Repository.Postagens;

namespace ProjetoFinalGeneration.Controllers
{
    [ApiController]
    [Route("api/postagens")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postagem>>> GetPostagens()
        {
            var postagens = await _postagemService.GetAllPostagensAsync();
            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Postagem>> GetPostagemById(int id)
        {
            var postagem = await _postagemService.GetPostagemByIdAsync(id);
            if (postagem == null)
                return NotFound(new { message = "Postagem não encontrada"});

            return Ok(postagem);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePostagem(Postagem postagem)
        {
            await _postagemService.CreatePostagemAsync(postagem);
            return CreatedAtAction(nameof(GetPostagemById), new { id = postagem.Id }, postagem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePostagem(int id, Postagem postagem)
        {
            if (id != postagem.Id)
                return BadRequest(new { message = "Postagem não encontrada"});

            await _postagemService.UpdatePostagemAsync(postagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostagem(int id)
        {
            await _postagemService.DeletePostagemAsync(id);
            return NoContent();
        }
    }
}
