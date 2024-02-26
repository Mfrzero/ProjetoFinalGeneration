using Microsoft.EntityFrameworkCore;
using ProjetoFinalGeneration.Data;

namespace ProjetoFinalGeneration.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }


    }
}
