using Shared.Dtos;

namespace Abstractions.Products;

/// <summary>
/// Defines the contract for a service that manages products.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductDto"/> as the result.</returns>
    Task<ProductDto> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductDto"/> as the result.</returns>
    Task<IReadOnlyList<ProductDto>> GetAllAsync();

    ///// <summary>
    ///// Adds a new product.
    ///// </summary>
    ///// <param name="entity">The product to add.</param>
    ///// <returns>A task representing the asynchronous operation, with the identifier of the newly created product as the result.</returns>
    //Task<ServiceResponse> AddAsync(CreateProductDto entity);

    ///// <summary>
    ///// Updates an existing product.
    ///// </summary>
    ///// <param name="entity">The product to update.</param>
    ///// <returns>A task representing the asynchronous operation, with the identifier of the updated product as the result.</returns>
    //Task<ServiceResponse> UpdateAsync(CreateProductDto entity);

    ///// <summary>
    ///// Deletes a product by its identifier.
    ///// </summary>
    ///// <param name="id">The identifier of the product to delete.</param>
    ///// <returns>A task representing the asynchronous operation, with the identifier of the deleted product as the result.</returns>
    //Task<ServiceResponse> DeleteAsync(int id);
}