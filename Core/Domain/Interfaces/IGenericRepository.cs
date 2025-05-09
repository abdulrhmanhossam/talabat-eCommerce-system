﻿using Domain.Abstract;
using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Generic repository interface for handling database operations.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
/// <typeparam name="TKey">The key type of the entity.</typeparam>
public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
    Task<TEntity?> GetEntityWithSpecificationAsync(Specification<TEntity> specification);
    Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(Specification<TEntity> specification);
    Task<int> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(int id);
    Task<int> CountAsync(Specification<TEntity> specification);
}