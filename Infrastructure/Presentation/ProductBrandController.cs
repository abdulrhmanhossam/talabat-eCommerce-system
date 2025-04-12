using Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

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
    public async Task<IActionResult> GetProductBrands()
    {
        var productBrands = await _serviceManager.ProductBrandService.GetAllAsync();
        return productBrands.Any() ? Ok(productBrands) : NotFound(productBrands);
    }

    /// <summary>
    /// Retrieves a product brand by its ID.
    /// </summary>
    /// <param name="id">The ID of the product brand.</param>
    /// <returns>The product brand if found; otherwise, NotFound response.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductBrand(int id)
    {
        var productBrand = await _serviceManager.ProductBrandService.GetByIdAsync(id);
        return productBrand != null ? Ok(productBrand) : NotFound(productBrand);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateProductBrandDto productBrand)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _serviceManager.ProductBrandService
            .AddAsync(productBrand);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(ProductBrandDto productBrand)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _serviceManager.ProductBrandService
            .UpdateAsync(productBrand);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.ProductBrandService
            .DeleteAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}
