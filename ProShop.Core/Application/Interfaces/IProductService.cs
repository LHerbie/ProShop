using ProShop.Core.DTOs;

namespace ProShop.Core.Application;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetAllProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductGetDto>> GetProductsByCategoryAsync(string category);
    Task<ProductGetDto> CreateProductAsync(ProductPostPutDto productPostPutDto);

    Task<ProductGetDto> UpdateProductAsync(int id, ProductPostPutDto productPostPutDto);
    
    Task DeleteProduct(int id);
}