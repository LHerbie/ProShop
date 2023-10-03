using ProShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProShop.Core.Infrastructure;

public class ProShopContext : DbContext
{
    public ProShopContext(DbContextOptions<ProShopContext> options) : base(options) { }
    
    public DbSet<MenuItem> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}