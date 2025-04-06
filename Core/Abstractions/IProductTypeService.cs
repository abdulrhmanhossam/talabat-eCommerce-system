using Shared.Dtos;

namespace Abstractions;

/// <summary>
/// Defines the contract for a service that manages product types.
/// </summary>
public interface IProductTypeService
{
    /// <summary>
    /// Retrieves a product type by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product type.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductTypeDto"/> as the result.</returns>
    Task<ProductTypeDto> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all product types.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductTypeDto"/> as the result.</returns>
    Task<IReadOnlyList<ProductTypeDto>> GetAllAsync();

    /// <summary>
    /// Adds a new product type.
    /// </summary>
    /// <param name="entity">The product type to add.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the newly created product type as the result.</returns>
    Task<int> AddAsync(CreateProductTypeDto entity);

    /// <summary>
    /// Updates an existing product type.
    /// </summary>
    /// <param name="entity">The product type to update.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the updated product type as the result.</returns>
    Task<int> UpdateAsync(ProductTypeDto entity);

    /// <summary>
    /// Deletes a product type by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product type to delete.</param>
    /// <returns>A task representing the asynchronous operation, with the identifier of the deleted product type as the result.</returns>
    Task<int> DeleteAsync(int id);
}