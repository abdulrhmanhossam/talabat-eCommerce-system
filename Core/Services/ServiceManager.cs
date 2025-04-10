using Abstractions;
using Abstractions.Products;
using AutoMapper;
using Domain.Interfaces;
using Services.Products;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IProductBrandService> _productBrandService;
    private readonly Lazy<IProductTypeService> _productTypeService;

    public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productService = new Lazy<IProductService>(
            () => new ProductService(unitOfWork, mapper));
        _productBrandService = new Lazy<IProductBrandService>(
            () => new ProductBrandService(unitOfWork, mapper));
        _productTypeService = new Lazy<IProductTypeService>(
            () => new ProductTypeService(unitOfWork, mapper));
    }

    public IProductService ProductService => _productService.Value;
    public IProductBrandService ProductBrandService => _productBrandService.Value;
    public IProductTypeService ProductTypeService => _productTypeService.Value;
}
