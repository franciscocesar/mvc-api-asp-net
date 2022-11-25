using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync([FromServices]AppDbContext context )
    {
        var categories = await context.Categories.ToListAsync();
        return Ok(categories);
    }
    
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync( [FromRoute] int id,[FromServices]AppDbContext context )
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    
    [HttpGet("v1/categories")]
    public async Task<IActionResult> PostAsync( [FromBody] EditorCategoryViewModel model,[FromServices]AppDbContext context )
    {
        try
        {
            var category = new Category
            {
                Id = 0,
                Name = model.Name, 
                Slug = model.Slug
            }; 
            
            
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return Created($"v1/categories/{category.Id}", category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Falha interna no servidor");
        }
    }
    
    
    
}