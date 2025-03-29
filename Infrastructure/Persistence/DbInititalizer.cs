using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Text.Json;

namespace Persistence;

public class DbInititalizer : IDbInititalizer
{
    private readonly AppDbContext _dbContext;

    public DbInititalizer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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
