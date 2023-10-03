using ProShop.Core.Domain;

namespace ProShop.Core.Application;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
}