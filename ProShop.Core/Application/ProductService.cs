using ProShop.Core.Domain;
using ProShop.Core.Dtos;

namespace ProShop.Core.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    private readonly ICategoryRepository _categoryRepository;


    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<IEnumerable<ProductGetDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(product => product.ToDto());
    }

    public async Task<ProductGetDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);

        return product.ToDto();
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsByCategoryAsync(string category)
    {
        Category verifiedCategory = await _categoryRepository.GetCategoryAsync(category);
        var products = await _productRepository.GetByCategoryAsync(verifiedCategory.Id);

        return products.Select(product => product.ToDto());
    }

    public async Task<ProductGetDto> CreateProductAsync(ProductPostPutDto productPostPutDto)
    {
        Category verifiedCategory = await _categoryRepository.GetCategoryAsync(productPostPutDto.Category);

        Product productToPost = productPostPutDto.ToDomain();
        productToPost.Category = verifiedCategory;
        productToPost.CategoryId = verifiedCategory.Id;

        Product productPosted = await _productRepository.CreateAsync(productToPost);

        return productPosted.ToDto();
    }
    public async Task<ProductGetDto> UpdateProductAsync(int id, ProductPostPutDto productPostPutDto)
    {
        Category verifiedCategory = await _categoryRepository.GetCategoryAsync(productPostPutDto.Category);
        
        Product productToPut = productPostPutDto.ToDomain();
        productToPut.Id = id;
        productToPut.Category = verifiedCategory;
        productToPut.CategoryId = verifiedCategory.Id;
        
        Product productPosted = await _productRepository.CreateAsync(productToPut);

        return productPosted.ToDto();
    }

    public async Task DeleteProduct(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}