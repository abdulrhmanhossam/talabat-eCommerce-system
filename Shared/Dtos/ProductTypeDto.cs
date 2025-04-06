namespace Shared.Dtos;

/// <summary>
/// Represents a data transfer object for a product type.
/// </summary>
public record ProductTypeDto
{
    /// <summary>
    /// Gets or sets the identifier of the product type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product type.
    /// </summary>
    public string Name { get; set; } = null!;
}