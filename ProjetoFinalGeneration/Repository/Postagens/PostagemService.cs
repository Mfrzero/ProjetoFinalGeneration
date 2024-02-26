using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Repository.Postagens
{
    public class PostagemService : IPostagemService
    {
        private readonly IRepository<Postagem> _postagemRepository;

        public PostagemService(IRepository<Postagem> postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task<IEnumerable<Postagem>> GetAllPostagensAsync()
        {
            return await _postagemRepository.GetAllAsync();
        }

        public async Task<Postagem> GetPostagemByIdAsync(int id)
        {
            return await _postagemRepository.GetByIdAsync(id);
        }

        public async Task CreatePostagemAsync(Postagem postagem)
        {
            await _postagemRepository.CreateAsync(postagem);
        }

        public async Task UpdatePostagemAsync(Postagem postagem)
        {
            await _postagemRepository.UpdateAsync(postagem);
        }

        public async Task DeletePostagemAsync(int id)
        {
            await _postagemRepository.DeleteAsync(id);
        }
    }
}
