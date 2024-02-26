using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Repository.Temas
{
    public class TemaService : ITemaService
    {
        private readonly IRepository<Tema> _temaRepository;

        public TemaService(IRepository<Tema> temaRepository)
        {
            _temaRepository = temaRepository;
        }

        public async Task<IEnumerable<Tema>> GetAllTemasAsync()
        {
            return await _temaRepository.GetAllAsync();
        }

        public async Task<Tema> GetTemaByIdAsync(int id)
        {
            return await _temaRepository.GetByIdAsync(id);
        }

        public async Task CreateTemaAsync(Tema tema)
        {
            await _temaRepository.CreateAsync(tema);
        }

        public async Task UpdateTemaAsync(Tema tema)
        {
            await _temaRepository.UpdateAsync(tema);
        }

        public async Task DeleteTemaAsync(int id)
        {
            await _temaRepository.DeleteAsync(id);
        }
    }
}
