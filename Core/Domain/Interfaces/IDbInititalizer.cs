namespace Domain.Interfaces;

/// <summary>
/// Defines the contract for database initialization operations
/// </summary>
public interface IDbInititalizer
{
    /// <summary>
    /// Performs database initialization tasks including migrations and data seeding
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation</returns>
    Task InitializeAsync();
}
