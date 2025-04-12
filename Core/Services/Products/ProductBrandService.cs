using Abstractions.Products;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared;
using Shared.Dtos;

namespace Services.Products;

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

    /// <summary>
    /// Adds a new product brand asynchronously.
    /// </summary>
    /// <param name="entity">The product brand data transfer object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> AddAsync(CreateProductBrandDto entity)
    {
        var mappedData = _mapper.Map<ProductBrand>(entity);
        int result = await _unitOfWork.GetRepository<ProductBrand, int>()
            .AddAsync(mappedData);

        return result > 0
            ? new ServiceResponse(true, "Product Brand Added")
            : new ServiceResponse(false, "Product Brand failed to be Added");
    }

    /// <summary>
    /// Updates a product brand asynchronously.
    /// </summary>
    /// <param name="entity">The product brand data transfer object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> UpdateAsync(ProductBrandDto entity)
    {
        var productBrand = await _unitOfWork.GetRepository<ProductBrand, int>()
            .GetByIdAsync(entity.Id);
        var mappedData = _mapper.Map(entity, productBrand);
        int result = await _unitOfWork.GetRepository<ProductBrand, int>()
            .UpdateAsync(mappedData!);

        return result > 0
            ? new ServiceResponse(true, "Product Brand Updated")
            : new ServiceResponse(false, "Product Brand failed to be Updated");
    }

    /// <summary>
    /// Deletes a product brand by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The product brand identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        int result = await _unitOfWork.GetRepository<ProductBrand, int>()
            .DeleteAsync(id);

        return result > 0
            ? new ServiceResponse(true, "Product Brand Deleted")
            : new ServiceResponse(false, "Product Brand Not Found or failed to be Deleted");
    }
}