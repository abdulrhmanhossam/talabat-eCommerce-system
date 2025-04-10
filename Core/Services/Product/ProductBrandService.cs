using Abstractions.Product;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Dtos;

namespace Services.Product;

/// <summary>
/// Provides services for managing product brands.
/// </summary>
public class ProductBrandService : IProductBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductBrandService"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public ProductBrandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a product brand by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product brand.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductBrandDto"/> as the result.</returns>
    public async Task<ProductBrandDto> GetByIdAsync(int id)
    {
        var productbrand = await _unitOfWork
            .GetRepository<ProductBrand, int>().GetByIdAsync(id);
        return _mapper.Map<ProductBrandDto>(productbrand);
    }

    /// <summary>
    /// Retrieves all product brands.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductBrandDto"/> as the result.</returns>
    public async Task<IReadOnlyList<ProductBrandDto>> GetAllAsync()
    {
        var productbrands = await _unitOfWork
            .GetRepository<ProductBrand, int>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductBrandDto>>(productbrands);
    }
}