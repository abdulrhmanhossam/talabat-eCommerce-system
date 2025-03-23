namespace Domain.Entities;

/// <summary>
/// Represents the base entity with an identifier.
/// </summary>
/// <typeparam name="TKey">The type of the identifier.</typeparam>
public abstract class BaseEntity<TKey>
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public TKey Id { get; set; }
}
