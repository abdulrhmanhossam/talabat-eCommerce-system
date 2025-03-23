namespace Domain.Entities;

/// <summary>
/// Represents a brand of a product.
/// </summary>
public class ProductBrand : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets the name of the product brand.
    /// </summary>
    public string Name { get; set; } = null!;
}
