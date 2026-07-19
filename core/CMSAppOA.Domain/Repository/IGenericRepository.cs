namespace CMSAppOA.Domain.Repository;

public interface IGenericRepository<T> where T : class, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}
