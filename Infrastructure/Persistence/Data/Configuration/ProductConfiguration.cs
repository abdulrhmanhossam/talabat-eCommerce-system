using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
/// <summary>
/// Configures the database schema for the <see cref="Product"/> entity.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Product"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the <see cref="Product"/> entity.</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.Price)
            .HasColumnType("decimal(18,3)");

        builder
            .HasOne(p => p.ProductBrand)
            .WithMany()
            .HasForeignKey(p => p.BrandId);

        builder
            .HasOne(p => p.ProductType)
            .WithMany()
            .HasForeignKey(p => p.TypeId);
    }
}
