using ProShop.Core.Application;
using ProShop.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProShop.API.Controllers;

public class CategoryController  : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    [Route("Categories")]
    public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet]
    [Route("Category/{Id:int}")]
    public async Task<ActionResult<CategoryGetDto>> GetCategoryById(int Id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(Id);
            return Ok(category);
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    [Route("Category")]
    public async Task<ActionResult<IEnumerable<CategoryGetDto>>> CreateCategory(
        [Microsoft.AspNetCore.Mvc.FromBody] CategoryPostPutDto categoryPostPutDto)
    {
        var newItem = await _categoryService.CreateCategoryAsync(categoryPostPutDto);

        return CreatedAtAction(nameof(GetCategoryById),
            new { newItem.Id }, newItem);
        
        
    }
    
    [HttpPut("Category/{Id:int}")]
    public async Task<ActionResult<CategoryGetDto>> UpdateCategory(int Id, 
        [Microsoft.AspNetCore.Mvc.FromBody] CategoryPostPutDto categoryPostPutDto)
    {
        try
        {
            var updatedItem = await _categoryService.UpdateCategoryAsync(Id, categoryPostPutDto);

            return Ok(updatedItem);
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("Category/{Id:int}")]
    public async Task<ActionResult> DeleteCategory(int Id)
    {
        try
        {
            await _categoryService.DeleteCategory(Id);
            return NoContent();
        }
        catch (ModelNotFoundException)
        {
            return NotFound();
        }
    }
}