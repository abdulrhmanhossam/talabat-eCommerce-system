using Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation;

/// <summary>
/// Handles HTTP requests related to product brands.
/// </summary>
public class ProductBrandController : BaseApiController
{
    private readonly IServiceManager _serviceManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductBrandController"/> class.
    /// </summary>
    /// <param name="serviceManager">The service manager providing access to product brand services.</param>
    public ProductBrandController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Retrieves all available product brands.
    /// </summary>
    /// <returns>A list of product brands if available; otherwise, NotFound response.</returns>
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var productbrands = await _serviceManager.ProductBrandService.GetAllAsync();
        return productbrands.Any() ? Ok(productbrands) : NotFound(productbrands);
    }

    /// <summary>
    /// Retrieves a product brand by its ID.
    /// </summary>
    /// <param name="id">The ID of the product brand.</param>
    /// <returns>The product brand if found; otherwise, NotFound response.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var productbrand = await _serviceManager.ProductBrandService.GetByIdAsync(id);
        return productbrand != null ? Ok(productbrand) : NotFound(productbrand);
    }
}
