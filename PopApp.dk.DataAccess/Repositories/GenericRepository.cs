using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PopApp.dk.DataAccess.DataContext;
using PopApp.dk.DataAccess.Repositories.IRepositories;

namespace PopApp.dk.DataAccess.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly PopappDbContext _popappDbContext;
    public GenericRepository(PopappDbContext popappDbContext)
    {
        _popappDbContext = popappDbContext;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await _popappDbContext.AddAsync(entity);
        await _popappDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddRange(List<TEntity> entity)
    {
        await _popappDbContext.AddRangeAsync(entity);
        await _popappDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> Delete(TEntity entity)
    {
        _ = _popappDbContext.Remove(entity);
        return await _popappDbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter = null)
    {
        return await _popappDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task<List<TEntity>?> GetList(Expression<Func<TEntity, bool>>? filter = null)
    {
        return await (filter == null ? _popappDbContext.Set<TEntity>().ToListAsync() : _popappDbContext.Set<TEntity>().Where(filter).ToListAsync());
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _ = _popappDbContext.Update(entity);
        await _popappDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
    {
        _popappDbContext.UpdateRange(entity);
        await _popappDbContext.SaveChangesAsync();
        return entity;
    }
}