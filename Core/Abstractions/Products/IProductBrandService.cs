using Shared;
using Shared.Dtos;

namespace Abstractions.Products;

/// <summary>
/// Defines the contract for a service that manages product brands.
/// </summary>
public interface IProductBrandService
{
    /// <summary>
    /// Retrieves a product brand by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product brand.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductBrandDto"/> as the result.</returns>
    Task<ProductBrandDto> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all product brands.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductBrandDto"/> as the result.</returns>
    Task<IReadOnlyList<ProductBrandDto>> GetAllAsync();

    /// <summary>
    /// Adds a new product brand.
    /// </summary>
    /// <param name="entity">The product brand to add.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the newly created product brand as the result.</returns>
    Task<ServiceResponse> AddAsync(CreateProductBrandDto entity);

    /// <summary>
    /// Updates an existing product brand.
    /// </summary>
    /// <param name="entity">The product brand to update.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the updated product brand as the result.</returns>
    Task<ServiceResponse> UpdateAsync(ProductBrandDto entity);

    /// <summary>
    /// Deletes a product brand by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product brand to delete.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the deleted product brand as the result.</returns>
    Task<ServiceResponse> DeleteAsync(int id);
}