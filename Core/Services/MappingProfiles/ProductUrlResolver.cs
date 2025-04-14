using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared.Dtos;

namespace Services.MappingProfiles;

/// <summary>
/// Resolves the full URL for the product picture by appending the base API URL.
/// </summary>
public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUrlResolver"/> class.
    /// </summary>
    /// <param name="configuration">The application configuration to retrieve the base API URL.</param>
    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Resolves the complete picture URL for the product by combining the API base URL with the picture path.
    /// </summary>
    /// <param name="source">The source product entity.</param>
    /// <param name="destination">The destination product DTO.</param>
    /// <param name="destMember">The destination member (unused).</param>
    /// <param name="context">The AutoMapper resolution context.</param>
    /// <returns>The full URL for the product's picture, or null if not available.</returns>
    public string Resolve(Product source, ProductDto destination,
        string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
            return _configuration["ApiUrl"] + source.PictureUrl;

        return null!;
    }
}
