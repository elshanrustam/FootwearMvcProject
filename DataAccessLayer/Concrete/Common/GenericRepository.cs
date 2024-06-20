using DataAccessLayer.Abstract.Common;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly FootDbContext _context;
    public DbSet<T> Table => _context.Set<T>();
    public GenericRepository(FootDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AddAsync(T entity)
    {
        var addedState = await Table.AddAsync(entity);
        return addedState.State == EntityState.Added;
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
    {
        if (tracking is false)
        {
            return await Table.AsNoTracking().ToListAsync();
        }
        return await Table.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) 
                                       => await Table.FindAsync(id);

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression) 
                                      => await Table.Where(expression).ToListAsync();

    public bool Remove(T entity)
    {
        var removed = Table.Remove(entity);
        return removed.State == EntityState.Deleted;
    }
    public bool Update(T entity)
    {
        var updated = Table.Update(entity);
        return updated.State == EntityState.Modified;
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
