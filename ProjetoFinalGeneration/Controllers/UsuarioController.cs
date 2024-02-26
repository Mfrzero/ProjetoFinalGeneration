using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalGeneration.Data;
using ProjetoFinalGeneration.Models;
using ProjetoFinalGeneration.Repository.Usuarios;

namespace ProjetoFinalGeneration.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ApplicationDbContext _rep;

        public UsuarioController(IUsuarioService usuarioService, ApplicationDbContext rep)
        {
            _usuarioService = usuarioService;
            _rep = rep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
                return NotFound(new { message = "Usuário não encontrado"});

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(Usuario usuario)
        {
            if (_rep.Usuarios.Any(u => u.Email == usuario.Email))
            {
                ModelState.AddModelError("Email", "Email deve ser único.");
                return BadRequest(ModelState);
            }
            await _usuarioService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest(new {message = "Usuário não encontrado"});

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
