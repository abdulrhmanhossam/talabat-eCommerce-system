namespace Shared.Dtos;

/// <summary>
/// Represents a data transfer object for a product brand.
/// </summary>
public record ProductBrandDto
{
    /// <summary>
    /// Gets or sets the identifier of the product brand.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product brand.
    /// </summary>
    public string Name { get; set; } = null!;
}