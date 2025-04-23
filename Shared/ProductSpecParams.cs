using Shared.Enums;

namespace Shared;
/// <summary>
/// Represents parameters used for filtering and sorting product queries.
/// </summary>
public class ProductSpecParams
{
    public int? TypeId { get; set; }
    public int? BrandId { get; set; }
    public ProductSpecSort? Sort { get; set; }
}
