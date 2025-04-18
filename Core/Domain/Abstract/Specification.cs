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
    /// Gets the expression used to determine the property to order by (ascending).
    /// </summary>
    public Expression<Func<T, object>> OrderBy { get; private set; }

    /// <summary>
    /// Gets the expression used to determine the property to order by (descending).
    /// </summary>
    public Expression<Func<T, object>> OrderByDescending { get; private set; }


    /// <summary>
    /// Adds a related entity to include in the query.
    /// </summary>
    /// <param name="includeExpression">The expression representing the related entity to include.</param>
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
        => Includes.Add(includeExpression);

    /// <summary>
    /// Specifies the property to order the query results by in ascending order.
    /// </summary>
    /// <param name="orderExpression">The expression representing the property to sort by.</param>
    protected void AddOrder(Expression<Func<T, object>> orderExpression)
        => OrderBy = orderExpression;

    /// <summary>
    /// Specifies the property to order the query results by in descending order.
    /// </summary>
    /// <param name="orderExpression">The expression representing the property to sort by.</param>
    protected void AddOrderByDescending(Expression<Func<T, object>> orderExpression)
        => OrderByDescending = orderExpression;
}