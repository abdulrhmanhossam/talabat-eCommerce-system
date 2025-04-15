using Domain.Abstract;
using Domain.Entities;

namespace Services.Specifications;

/// <summary>
/// Specification for retrieving products with their associated brand and type.
/// </summary>
public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsWithTypesAndBrandsSpecification"/> class
    /// to retrieve a specific product by its ID, including its brand and type.
    /// </summary>
    /// <param name="id">The product ID to filter by.</param>
    public ProductsWithTypesAndBrandsSpecification(int id)
        : base(product => product.Id == id)
    {
        AddInclude(product => product.ProductBrand);
        AddInclude(product => product.ProductType);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsWithTypesAndBrandsSpecification"/> class
    /// to retrieve all products including their brand and type.
    /// </summary>
    public ProductsWithTypesAndBrandsSpecification()
        : base(product => true)
    {
        AddInclude(product => product.ProductBrand);
        AddInclude(product => product.ProductType);
    }
}
