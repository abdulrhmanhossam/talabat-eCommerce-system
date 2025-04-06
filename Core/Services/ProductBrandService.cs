using Abstractions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Dtos;

namespace Services;

public class ProductBrandService : IProductBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductBrandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductBrandDto> GetByIdAsync(int id)
    {
        var productbrand = await _unitOfWork
            .GetRepository<ProductBrand, int>().GetByIdAsync(id);
        return _mapper.Map<ProductBrandDto>(productbrand);
    }

    public async Task<IReadOnlyList<ProductBrandDto>> GetAllAsync()
    {
        var productbrands = await _unitOfWork
            .GetRepository<ProductBrand, int>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductBrandDto>>(productbrands);
    }
}
