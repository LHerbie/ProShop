using System.Runtime.Intrinsics.Arm;
using ProShop.Core.Domain;

namespace ProShop.Core.DTOs;

public static class CategoryMapper
{
    public static CategoryGetDto ToDto(this Domain.Category category)
    {
        return new CategoryGetDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static Domain.Category ToDomain(this CategoryPostPutDto categoryPostPutDto)
    {
        return new Domain.Category
        {
            Name = categoryPostPutDto.Name
        };
    }
}