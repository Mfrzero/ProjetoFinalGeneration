using ProjetoFinalGeneration.Models;

namespace ProjetoFinalGeneration.Repository.Postagens
{
    public interface IPostagemService
    {
        Task<IEnumerable<Postagem>> GetAllPostagensAsync();
        Task<Postagem> GetPostagemByIdAsync(int id);
        Task CreatePostagemAsync(Postagem postagem);
        Task UpdatePostagemAsync(Postagem postagem);
        Task DeletePostagemAsync(int id);
    }
}
