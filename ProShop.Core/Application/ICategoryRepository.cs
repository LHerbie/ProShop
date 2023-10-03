using ProShop.Core.Domain;

namespace ProShop.Core.Application;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetCategoryAsync(string name);
}