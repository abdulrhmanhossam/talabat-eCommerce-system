namespace Domain.Entities;

/// <summary>
/// Represents a type of product.
/// </summary>
public class ProductType : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets the name of the product type.
    /// </summary>
    public string Name { get; set; } = null!;
}
