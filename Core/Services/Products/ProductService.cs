﻿using Abstractions.Products;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Services.Specifications;
using Shared.Dtos;

namespace Services.Products;

/// <summary>
/// Provides services for managing products.
/// </summary>
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="mapper">The mapper.</param>
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a read-only list of <see cref="ProductDto"/> as the result.</returns>
    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(string? sort,
        int? brandId, int? typeId)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(sort, brandId, typeId);
        var products = await _unitOfWork
            .GetRepository<Product, int>()
            .GetAllWithSpecificationAsync(spec);
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    /// <summary>
    /// Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product.</param>
    /// <returns>A task representing the asynchronous operation, with a <see cref="ProductDto"/> as the result.</returns>
    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);
        var products = await _unitOfWork
            .GetRepository<Product, int>().
            GetEntityWithSpecificationAsync(spec);
        return _mapper.Map<ProductDto>(products);
    }
}