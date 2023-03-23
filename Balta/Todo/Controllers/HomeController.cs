using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Todos2.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var todos = context.Todos2.FirstOrDefault(x => x.Id == id);
            if (todos is null)
                return NotFound();

            return Ok(todos);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.Todos2.Add(todo);
            context.SaveChanges();

            return Created($"/(todo.Id", todo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos2.FirstOrDefault(x => x.Id == id);
            if (model is null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;
            context.Todos2.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos2.FirstOrDefault(x => x.Id == id);
            if (model is null)
                return NotFound();
            context.Todos2.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}