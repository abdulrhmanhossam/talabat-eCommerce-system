using Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation;

/// <summary>
/// Handles product-related HTTP requests.
/// </summary>
public class ProductController : BaseApiController
{
    private readonly IServiceManager _serviceManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="serviceManager">The service manager that provides access to product services.</param>
    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Retrieves all available products.
    /// </summary>
    /// <returns>A list of products if found; otherwise, a NotFound response.</returns>
    [HttpGet]
    public async Task<IActionResult> GetProducts(string? sort, int? brandId, int? typeId)
    {
        var products = await _serviceManager.ProductService.GetAllAsync(sort, brandId, typeId);
        return products.Any() ? Ok(products) : NotFound(products);
    }

    /// <summary>
    /// Retrieves a specific product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The product if found; otherwise, a NotFound response.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(id);
        return product != null ? Ok(product) : NotFound(product);
    }
}
