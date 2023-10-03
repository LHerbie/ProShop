using ProShop.Core.DTOs;

namespace ProShop.Core.Application;

public class CategoryService : ICategoryService
{
    public Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> CreateCategoryAsync(CategoryPostPutDto CategoryPostPutDto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> UpdateCategoryAsync(int id, CategoryPostPutDto CategoryPostPutDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}