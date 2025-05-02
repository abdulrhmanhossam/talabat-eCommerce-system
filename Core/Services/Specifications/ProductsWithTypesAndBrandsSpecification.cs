using Domain.Abstract;
using Domain.Entities;
using Shared;
using Shared.Enums;

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
    public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(product =>
        (!productParams.BrandId.HasValue || product.BrandId == productParams.BrandId.Value)
        && (!productParams.TypeId.HasValue || product.TypeId == productParams.TypeId.Value)
        && (string.IsNullOrWhiteSpace(productParams.Search) || product.Name.ToLower()
        .Contains(productParams.Search.ToLower().Trim())))
    {
        AddInclude(product => product.ProductBrand);
        AddInclude(product => product.ProductType);
        ApplyPagination(productParams.PageIndex, productParams.PageSize);

        AddOrder(product => product.Name);

        if (productParams.Sort is not null)
        {
            switch (productParams.Sort)
            {
                case ProductSpecSort.NameAsc:
                    AddOrder(p => p.Name);
                    break;

                case ProductSpecSort.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSpecSort.PriceAsc:
                    AddOrder(p => p.Price);
                    break;
                case ProductSpecSort.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
            }
        }
    }
}
