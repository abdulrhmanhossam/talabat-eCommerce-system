using Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

/// <summary>
/// Provides functionality to evaluate a specification and convert it into a LINQ query.
/// This includes applying filtering, eager-loading, sorting, and pagination.
/// </summary>
public static class SpecificationEvaluator
{
    /// <summary>
    /// Builds an <see cref="IQueryable{T}"/> based on the provided specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="inputQuery">The base query to apply the specification to.</param>
    /// <param name="specification">The specification containing criteria, includes, sorting, and pagination info.</param>
    /// <returns>An <see cref="IQueryable{T}"/> with the applied specification logic.</returns>
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> inputQuery,
        Specification<T> specification)
        where T : class
    {
        var query = inputQuery;

        // Apply filtering criteria
        if (specification.Criteria != null)
            query = query.Where(specification.Criteria);

        // Apply eager loading
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        // Apply sorting
        if (specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);
        else if (specification.OrderByDescending is not null)
            query = query.OrderByDescending(specification.OrderByDescending);

        // Apply pagination
        if (specification.IsPaginated)
            query = query.Skip(specification.Skip).Take(specification.Take);

        return query;
    }
}
