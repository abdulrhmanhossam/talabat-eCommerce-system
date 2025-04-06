namespace Shared.Dtos;

/// <summary>
/// Represents a data transfer object for a product.
/// </summary>
public record ProductDto
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public int Id { get; set; }

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
    /// Gets or sets the brand of the product.
    /// </summary>
    public string ProductBrand { get; set; } = null!;

    /// <summary>
    /// Gets or sets the type of the product.
    /// </summary>
    public string ProductType { get; set; } = null!;
}