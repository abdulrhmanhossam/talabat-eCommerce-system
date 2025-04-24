using Shared.Enums;

namespace Shared;
/// <summary>
/// Encapsulates query parameters used to filter, sort, and paginate product results.
/// </summary>
public class ProductSpecParams
{
    private const int _maxPageSize = 10;
    private const int _defaultPageSize = 5;

    /// <summary>
    /// Gets or sets the ID of the product type to filter by.
    /// </summary>
    public int? TypeId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the product brand to filter by.
    /// </summary>
    public int? BrandId { get; set; }

    /// <summary>
    /// Gets or sets the sorting option for the product list.
    /// </summary>
    public ProductSpecSort? Sort { get; set; }

    /// <summary>
    /// Gets or sets the current page index (1-based).
    /// </summary>
    public int PageIndex { get; set; } = 1;

    private int _pageSize = _defaultPageSize;

    /// <summary>
    /// Gets or sets the number of items per page, with a maximum limit.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }
}
