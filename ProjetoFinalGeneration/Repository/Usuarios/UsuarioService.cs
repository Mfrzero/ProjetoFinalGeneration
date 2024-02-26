using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Repository.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

    }
}
