namespace Domain.Entities;

/// <summary>
/// Represents a product.
/// </summary>
public class Product : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the image URL of the product.
    /// </summary>
    public string ImageUrl { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the brand identifier of the product.
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// Gets or sets the brand of the product.
    /// </summary>
    public ProductBrand ProductBrand { get; set; }

    /// <summary>
    /// Gets or sets the type identifier of the product.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Gets or sets the type of the product.
    /// </summary>
    public ProductType ProductType { get; set; }

}
