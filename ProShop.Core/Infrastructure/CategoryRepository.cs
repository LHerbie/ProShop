using ProShop.Core.Application;
using ProShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProShop.Core.Infrastructure;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProShopContext context) : base(context)
    {
        _entities = context.Categories;
    }
    public async Task<Category> GetCategoryAsync(string name)
    {
        var category = await _entities.AsNoTracking().SingleOrDefaultAsync(c => c.Name == name);

        if (category == null) throw new ModelNotFoundException();
        
        return category;
    }
}