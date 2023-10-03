using ProShop.Core.Application;
using ProShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProShop.API.Controllers;

public class ProductController  : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    [Route("Products")]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetAllProducts()
    {
        var items = await _productService.GetAllProductsAsync();

        return Ok(items);
    }

    [HttpGet]
    [Route("Product/{Id:int}")]
    public async Task<ActionResult<ProductGetDto>> GetProductById(int Id)
    {
        try
        {
            var item = await _productService.GetProductByIdAsync(Id);
            return Ok(item);
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    [Route("Products/CategoryName/{Category}")]
    public async Task<ActionResult<ProductGetDto>> GetProductsByCategory(string Category)
    {
        try
        {
            var items = await _productService.GetProductsByCategoryAsync(Category);
            return Ok(items);
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("Product")]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> CreateProduct(
        [Microsoft.AspNetCore.Mvc.FromBody] ProductPostPutDto itemPostPutDto)
    {
        var newItem = await _productService.CreateProductAsync(itemPostPutDto);

        return CreatedAtAction(nameof(GetProductById),
            new { newItem.Id }, newItem);
        
        
    }
    
    [HttpPut("Product/{Id:int}")]
    public async Task<ActionResult<ProductGetDto>> UpdateProduct(int Id, 
        [Microsoft.AspNetCore.Mvc.FromBody] ProductPostPutDto itemPostPutDto)
    {
        try
        {
            var updatedItem = await _productService.UpdateProductAsync(Id, itemPostPutDto);

            return Ok(updatedItem);
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("Product/{Id:int}")]
    public async Task<ActionResult> DeleteProduct(int Id)
    {
        try
        {
            await _productService.DeleteProduct(Id);
            return NoContent();
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
}