namespace Shared.Dtos;

/// <summary>
/// Represents a data transfer object for a product.
/// </summary>
public record ProductDto : BaseProductDto
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public int Id { get; set; }
}