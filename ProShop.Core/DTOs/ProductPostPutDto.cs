namespace ProShop.Core.DTOs;

public class ProductPostPutDto
{
    public string Name { get; set; }
    
    public string Category { get; set; }
    public int CategoryId { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
}