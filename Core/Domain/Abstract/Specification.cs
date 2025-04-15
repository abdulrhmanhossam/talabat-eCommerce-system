using System.Linq.Expressions;

namespace Domain.Abstract;

/// <summary>
/// Represents the base class for defining query specifications with filtering and including related entities.
/// </summary>
/// <typeparam name="T">The entity type the specification applies to.</typeparam>
public abstract class Specification<T> where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Specification{T}"/> class with a filtering criteria.
    /// </summary>
    /// <param name="criteria">The expression used to filter the entity.</param>
    protected Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    /// <summary>
    /// Gets the filtering criteria for the specification.
    /// </summary>
    public Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    /// Gets the list of related entities to include in the query.
    /// </summary>
    public List<Expression<Func<T, object>>> Includes { get; } = new();

    /// <summary>
    /// Adds a related entity to include in the query.
    /// </summary>
    /// <param name="includeExpression">The expression representing the related entity to include.</param>
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
        => Includes.Add(includeExpression);
}