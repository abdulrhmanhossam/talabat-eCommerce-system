using Abstractions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Dtos;

namespace Services;

public class ProductTypeService : IProductTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductTypeDto> GetByIdAsync(int id)
    {
        var producttype = await _unitOfWork
            .GetRepository<ProductType, int>().GetByIdAsync(id);
        return _mapper.Map<ProductTypeDto>(producttype);
    }

    public async Task<IReadOnlyList<ProductTypeDto>> GetAllAsync()
    {
        var producttypes = await _unitOfWork
            .GetRepository<ProductType, int>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductTypeDto>>(producttypes);
    }
}
