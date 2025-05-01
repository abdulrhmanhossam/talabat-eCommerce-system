namespace Shared;

/// <summary>
/// Represents a paginated result set for a query.
/// </summary>
/// <typeparam name="T">The type of items in the result set.</typeparam>
public class PaginatedResult<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedResult{T}"/> class.
    /// </summary>
    /// <param name="pageIndex">The current page index.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="totalCount">The total number of items.</param>
    /// <param name="data">The data items for the current page.</param>
    public PaginatedResult(int pageIndex, int pageSize, int totalCount,
        IEnumerable<T> data)
    {

    }
}
