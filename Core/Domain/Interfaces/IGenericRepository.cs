using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Generic repository interface for handling database operations.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TKey">The key type of the entity.</typeparam>
public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found.</returns>
    Task<TEntity> GetByIdAsync(TKey id);

    /// <summary>
    /// Retrieves all entities asynchronously with optional tracking.
    /// </summary>
    /// <param name="trackChanges">Indicates whether to track changes on the retrieved entities.</param>
    /// <returns>A collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges);

    /// <summary>
    /// Asynchronously adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);
}
