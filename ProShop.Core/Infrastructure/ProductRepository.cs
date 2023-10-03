using ProShop.Core.Application;
using ProShop.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace ProShop.Core.Infrastructure;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProShopContext context) : base(context)
    {
        _entities = context.Products;
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        var item = await Task.Run(() =>
            _entities.Include(product => product.Category).AsNoTracking().Where(i => i.CategoryId == categoryId));

        if (item == null) throw new MalformedLineException();

        return item;
    }
}