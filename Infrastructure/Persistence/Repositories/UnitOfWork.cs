using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using System.Collections.Concurrent;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly ConcurrentDictionary<string, object> _repositories;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new();
    }

    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        //var typeName = typeof(TEntity).Name;
        //if (_repositories.ContainsKey(typeName))
        //    return (IGenericRepository<TEntity, TKey>)_repositories[typeName];

        //var repository = new GenericRepository<TEntity, TKey>(_dbContext);
        //_repositories.GetOrAdd(typeName, repository);
        //return repository;

        return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, TKey>(_dbContext));
    }

    public async Task<int> SaveChanges()
        => await _dbContext.SaveChangesAsync();
}
