using AutoMapper;
using Domain.Entities;
using Shared.Dtos;

namespace Services.MappingProfiles;

/// <summary>
/// Defines the mapping profiles for AutoMapper to map between domain entities and DTOs.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// Configures the mappings between domain entities and DTOs.
    /// </summary>
    public MappingProfile()
    {
        /// <summary>
        /// Maps <see cref="Product"/> to <see cref="ProductDto"/>.
        /// Maps the ProductBrand and ProductType properties to their respective names.
        /// </summary>
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

        /// <summary>
        /// Maps <see cref="ProductBrand"/> to <see cref="ProductBrandDto"/> and vice versa.
        /// </summary>
        CreateMap<ProductBrand, ProductBrandDto>();
        CreateMap<ProductBrandDto, ProductBrand>();
        CreateMap<CreateProductBrandDto, ProductBrand>();

        /// <summary>
        /// Maps <see cref="ProductType"/> to <see cref="ProductTypeDto"/> and vice versa.
        /// </summary>
        CreateMap<ProductType, ProductTypeDto>();
        CreateMap<ProductTypeDto, ProductType>();
        CreateMap<CreateProductTypeDto, ProductType>();
    }
}