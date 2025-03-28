using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
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
