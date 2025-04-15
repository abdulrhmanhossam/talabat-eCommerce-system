using Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

/// <summary>
/// Provides functionality to evaluate a specification and convert it into a LINQ query.
/// This includes applying filtering criteria and eager-loading related entities.
/// </summary>
public static class SpecificationEvaluator
{
    /// <summary>
    /// Builds an <see cref="IQueryable{T}"/> based on the provided specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="inputQuery">The base query to apply the specification to.</param>
    /// <param name="specification">The specification containing criteria and includes.</param>
    /// <returns>A query with the applied filtering and includes.</returns>
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> inputQuery,
        Specification<T> specification)
        where T : class
    {
        var query = inputQuery;

        // Apply the criteria if it exists
        if (specification.Criteria != null)
            query = query.Where(specification.Criteria);

        // Apply the includes to the query
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        return query;
    }
}
