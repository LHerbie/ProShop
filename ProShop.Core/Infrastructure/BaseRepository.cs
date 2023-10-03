using ProShop.Core.Application;
using ProShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProShop.Core.Infrastructure;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected DbContext _context;
    protected DbSet<TEntity> _entities;

    public BaseRepository(ProShopContext context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Task.Run(() => _entities.AsNoTracking());
    }

    public virtual async Task<TEntity> GetAsync(int id)
    {
        var entity = await _entities.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);

        if (entity == null) throw new ModelNotFoundException();

        return entity;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        _entities.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await GetAsync(entity.Id);
        _entities.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entityToDelete = await GetAsync(id);
        _entities.Remove(entityToDelete);
        await _context.SaveChangesAsync();
    }
}