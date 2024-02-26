using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Repository.Temas
{
    public interface ITemaService
    {
        Task<IEnumerable<Tema>> GetAllTemasAsync();
        Task<Tema> GetTemaByIdAsync(int id);
        Task CreateTemaAsync(Tema tema);
        Task UpdateTemaAsync(Tema tema);
        Task DeleteTemaAsync(int id);
    }
}
