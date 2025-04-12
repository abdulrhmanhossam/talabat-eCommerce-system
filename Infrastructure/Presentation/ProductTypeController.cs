using Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Presentation;

/// <summary>
/// Handles HTTP requests related to product types.
/// </summary>
public class ProductTypeController : BaseApiController
{
    private readonly IServiceManager _serviceManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTypeController"/> class.
    /// </summary>
    /// <param name="serviceManager">The service manager providing access to product type services.</param>
    public ProductTypeController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    /// <summary>
    /// Retrieves all available product types.
    /// </summary>
    /// <returns>A list of product types if available; otherwise, NotFound response.</returns>
    [HttpGet]
    public async Task<IActionResult> GetProductTypes()
    {
        var productTypes = await _serviceManager.ProductTypeService.GetAllAsync();
        return productTypes.Any() ? Ok(productTypes) : NotFound(productTypes);
    }

    /// <summary>
    /// Retrieves a product type by its ID.
    /// </summary>
    /// <param name="id">The ID of the product type.</param>
    /// <returns>The product type if found; otherwise, NotFound response.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductType(int id)
    {
        var productType = await _serviceManager.ProductTypeService.GetByIdAsync(id);
        return productType != null ? Ok(productType) : NotFound(productType);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CreateProductTypeDto productType)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _serviceManager.ProductTypeService
            .AddAsync(productType);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(ProductTypeDto productType)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _serviceManager.ProductTypeService
            .UpdateAsync(productType);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceManager.ProductTypeService
            .DeleteAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}
