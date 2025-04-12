using Abstractions.Products;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared;
using Shared.Dtos;

namespace Services.Products;

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


    /// <summary>
    /// Adds a new product type asynchronously.
    /// </summary>
    /// <param name="entity">The product type data transfer object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> AddAsync(CreateProductTypeDto entity)
    {
        var mappedData = _mapper.Map<ProductType>(entity);
        int result = await _unitOfWork.GetRepository<ProductType, int>()
            .AddAsync(mappedData);

        return result > 0
            ? new ServiceResponse(true, "Product Type Added")
            : new ServiceResponse(false, "Product Type failed to be Added");
    }

    /// <summary>
    /// Updates a product type asynchronously.
    /// </summary>
    /// <param name="entity">The product type data transfer object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> UpdateAsync(ProductTypeDto entity)
    {
        var productType = await _unitOfWork.GetRepository<ProductType, int>()
            .GetByIdAsync(entity.Id);
        var mappedData = _mapper.Map(entity, productType);
        int result = await _unitOfWork.GetRepository<ProductType, int>()
            .UpdateAsync(mappedData!);

        return result > 0
            ? new ServiceResponse(true, "Product Type Updated")
            : new ServiceResponse(false, "Product Type failed to be Updated");
    }

    /// <summary>
    /// Deletes a product type by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The product type identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service response.</returns>
    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        int result = await _unitOfWork.GetRepository<ProductType, int>()
            .DeleteAsync(id);

        return result > 0
            ? new ServiceResponse(true, "Product Type Deleted")
            : new ServiceResponse(false, "Product Type Not Found or failed to be Deleted");
    }
}