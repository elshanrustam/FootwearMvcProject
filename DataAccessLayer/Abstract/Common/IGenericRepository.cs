using System.Linq.Expressions;

namespace DataAccessLayer.Abstract.Common;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
    Task<bool> AddAsync(T entity);
    Task SaveChangesAsync();
    bool Update(T entity);
    bool Remove(T entity);
}
