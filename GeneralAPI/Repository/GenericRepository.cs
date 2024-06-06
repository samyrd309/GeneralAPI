using GeneralAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBase
{
    private readonly PostgreDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(PostgreDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.Where(e => e.State).ToListAsync();
    }


    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.SingleOrDefaultAsync(e => e.EntityId == id && e.State == true);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.State = false;
            await _context.SaveChangesAsync();
        }
    }


}