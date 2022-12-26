using Blog.Data;
using Blog.Models;
using Blog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync(
        [FromServices] BlogDataContext context)
    {
        try
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(new ResultViewModel<List<Category>>(categories));
        }
        catch
        {
            return StatusCode(500, (new ResultViewModel<List<Category>>(" Falha interna")));
        }

    }

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] BlogDataContext context,
        [FromRoute] int id)
    {
        try
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return NotFound(new ResultViewModel<Category>("Nao ha categorias cadastradas"));

            return Ok(new ResultViewModel<Category>(category));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Category>(" Falha no servidor"));
        }

    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync(
        [FromServices] BlogDataContext context,
        [FromBody] EditorCategoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        try
        {
            var category = new Category
            {
                Id = 0,
                Name = model.Name,
                Slug = model.Slug,
            };

            await context.AddAsync(category);
            await context.SaveChangesAsync();

            return Created($"v1/categories/{category.Id}", category);
        }
        catch (Exception)
        {
            return BadRequest("Nao cadastrado - revise ");
        }

    }

    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromServices] BlogDataContext context,
        [FromBody] EditorCategoryViewModel model,
        [FromRoute] int id)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(z => z.Id == id);
            if (category == null) return NotFound();

            category.Name = model.Name;
            category.Slug = model.Slug;

            context.Categories.Update(category);
            await context.SaveChangesAsync();


            return Ok(category);
        }
        catch (Exception)
        {
            return BadRequest("revise os campos");
        }

    }

    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] BlogDataContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new ResultViewModel<Category>("Id Nao encontrado")) ;

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<Category>(category));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Category>("Falha no servidor"));
        }

    }



}
