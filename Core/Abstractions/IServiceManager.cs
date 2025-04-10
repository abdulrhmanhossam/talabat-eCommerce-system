using Abstractions.Product;

namespace Abstractions;

public interface IServiceManager
{
    public IProductService ProductService { get; }
    public IProductBrandService ProductBrandService { get; }
    public IProductTypeService ProductTypeService { get; }
}
