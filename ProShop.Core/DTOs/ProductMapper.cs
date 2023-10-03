using System.Runtime.Intrinsics.Arm;
using ProShop.Core.Domain;

namespace ProShop.Core.DTOs;

public static class ProductMapper
{
    public static ProductGetDto ToDto(this Domain.Product product)
    {
        return new ProductGetDto
        {
            Id = product.Id,
            Category = product.Category.Name,
            Description = product.Description,
            Price = product.Price.Value
        };
    }

    public static Domain.Product ToDomain(this ProductPostPutDto productPostPutDto)
    {
        return new Domain.Product
        {
            Description = productPostPutDto.Description,
            Price = new Money(productPostPutDto.Price)
        };
    }
}