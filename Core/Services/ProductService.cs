using Abstractions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Dtos;

namespace Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork
            .GetRepository<Product, int>().GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var products = await _unitOfWork
            .GetRepository<Product, int>().GetByIdAsync(id);
        return _mapper.Map<ProductDto>(products);
    }
}
