using Abstractions.Product;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Dtos;

namespace Services.Product;

/// <summary>
/// Provides services for managing product types.
/// </summary>
public class ProductTypeService : IProductTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTypeService"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a product type by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product type.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductTypeDto"/> as the result.</returns>
    public async Task<ProductTypeDto> GetByIdAsync(int id)
    {
        var producttype = await _unitOfWork
            .GetRepository<ProductType, int>().GetByIdAsync(id);
        return _mapper.Map<ProductTypeDto>(producttype);
    }

    /// <summary>
    /// Retrieves all product types.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductTypeDto"/> as the result.</returns>
    public async Task<IReadOnlyList<ProductTypeDto>> GetAllAsync()
    {
        var producttypes = await _unitOfWork
            .GetRepository<ProductType, int>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductTypeDto>>(producttypes);
    }
}