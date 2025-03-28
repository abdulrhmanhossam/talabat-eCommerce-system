using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

/// <summary>
/// Represents the database context for the application, providing access to the database tables
/// and configuring the entity relationships and schema.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to configure the database context.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    /// <summary>
    /// Configures the model and relationships for the database context using the specified <see cref="ModelBuilder"/>.
    /// </summary>
    /// <param name="modelBuilder">The builder used to configure the model for the database context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Applies all configurations from the current assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}