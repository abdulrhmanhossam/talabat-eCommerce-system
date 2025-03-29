using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text.Json;

namespace Persistence;

/// <summary>
/// Initializes the database by applying pending migrations and seeding data from JSON files.
/// </summary>
public class DbInititalizer : IDbInititalizer
{
    private readonly AppDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbInititalizer"/> class.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    public DbInititalizer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Ensures the database is migrated and seeded with initial data.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InitializeAsync()

    {
        try
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
                await _dbContext.Database.MigrateAsync();

            if (!_dbContext.ProductTypes.Any())
            {
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types is not null && types.Any())
                {
                    await _dbContext.ProductTypes.AddRangeAsync(types);
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (!_dbContext.ProductBrands.Any())
            {
                var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seed\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands is not null && brands.Any())
                {
                    await _dbContext.ProductBrands.AddRangeAsync(brands);
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (!_dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null && products.Any())
                {
                    await _dbContext.Products.AddRangeAsync(products);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
