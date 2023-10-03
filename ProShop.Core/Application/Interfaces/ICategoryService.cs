using ProShop.Core.DTOs;

namespace ProShop.Core.Application;

public interface ICategoryService
{
    Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync();
    Task<CategoryGetDto> GetCategoryByIdAsync(int id);
    Task<CategoryGetDto> CreateCategoryAsync(CategoryPostPutDto CategoryPostPutDto);
    Task<CategoryGetDto> UpdateCategoryAsync(int id, CategoryPostPutDto CategoryPostPutDto);
    Task DeleteCategory(int id);
}