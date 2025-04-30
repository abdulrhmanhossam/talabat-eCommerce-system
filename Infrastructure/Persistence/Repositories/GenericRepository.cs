using Domain.Abstract;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

/// <summary>
/// Generic repository for handling database operations for any entity type.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TKey">The key type of the entity.</typeparam>
public class GenericRepository<TEntity, TKey>
    : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{TEntity, TKey}"/> class.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
    public async Task<int> AddAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
    /// <exception cref="ItemNotFoundException">Thrown when the entity with the specified identifier is not found.</exception>
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id)
            ?? throw new Exception($"Item with {id} is not found");
        _dbContext.Set<TEntity>().Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
    public async Task<int> UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all entities asynchronously with optional tracking.
    /// </summary>
    /// <param name="trackChanges">Indicates whether to track changes on the retrieved entities.</param>
    /// <returns>A collection of entities.</returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
        => trackChanges ? await _dbContext.Set<TEntity>().ToListAsync()
            : await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new InvalidOperationException($"Entity of type {typeof(TEntity).Name} with ID {id} was not found.");
        }
        return entity;
    }


    public async Task<TEntity?> GetEntityWithSpecificationAsync(Specification<TEntity> specification)
        => await ApplySpecification(specification).FirstOrDefaultAsync();

    public async Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(Specification<TEntity> specification)
        => await ApplySpecification(specification).AsNoTracking().ToListAsync();

    private IQueryable<TEntity> ApplySpecification(Specification<TEntity> specification)
        => SpecificationEvaluator.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification);

    public async Task<int> CountAsync(Specification<TEntity> specification)
        => await SpecificationEvaluator
        .GetQuery(_dbContext.Set<TEntity>(), specification).CountAsync();
}
