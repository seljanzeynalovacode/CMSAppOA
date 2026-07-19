using CMSAppOA.Domain.Repository;
using CMSAppOA.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace CMSAppOA.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly CMSAppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(CMSAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

