using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogList.Controller
{
    [ApiController]
    [Route("vi/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext _context)
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] BlogDataContext _context,
            [FromRoute]int id)
        {
            var categories = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if(categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromServices] BlogDataContext _context,
            [FromBody] Category model)
        {
            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
            return Created($"v1/categories/{model.Id}", model);
        }


        [HttpPut("v1/categories/{int:id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] BlogDataContext _context,
            [FromBody] Category model,
            [FromRoute]int id)
        {
            var categories = await _context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            categories.Name = model.Name;
            categories.Slug= model.Slug;

            _context.Categories.Update(categories);
            await _context.SaveChangesAsync();
            return Ok(categories);
        }


        [HttpDelete("v1/categories/{int:id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] BlogDataContext _context,
            
            [FromRoute] int id)
        {
            var categories = await _context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return Ok(categories);
        }

    }
}
