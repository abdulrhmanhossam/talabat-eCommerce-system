using Domain.Abstract;
using Domain.Entities;
using Shared;

namespace Services.Specifications;

/// <summary>
/// Specification for counting products based on optional brand and type filters.
/// </summary>
public class ProductCountSpecifications : Specification<Product>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductCountSpecifications"/> class.
    /// </summary>
    /// <param name="productParams">The filtering parameters such as brand and type.</param>
    public ProductCountSpecifications(ProductSpecParams productParams)
        : base(product =>
        (!productParams.BrandId.HasValue || product.BrandId == productParams.BrandId.Value)
        && (!productParams.TypeId.HasValue || product.TypeId == productParams.TypeId.Value))
    {

    }
}
