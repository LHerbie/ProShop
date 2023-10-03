namespace ProShop.Core.Domain;

public class Product : BaseEntity
{
    public string Name { get; set; }
    
    public Category Category { get; set; }
    
    public int CategoryId { get; set; }
    
    public string Description { get; set; }
    
    public Money Price { get; set; }
}