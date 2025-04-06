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
    /// Asynchronously adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(TEntity entity)
        => await _dbContext.Set<TEntity>().AddAsync(entity);

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(TEntity entity)
        => _dbContext.Set<TEntity>().Remove(entity);

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(TEntity entity)
        => _dbContext.Set<TEntity>().Update(entity);

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
}
