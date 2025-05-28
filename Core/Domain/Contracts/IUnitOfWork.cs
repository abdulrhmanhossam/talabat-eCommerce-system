using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : BaseEntity<TKey>;
}