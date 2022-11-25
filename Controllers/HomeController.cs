using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context)
    {
        return Ok(context.Todos.ToList());
    }

    [HttpGet("/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var todo = context.Todos.FirstOrDefault(x => x.Id == id);

        if (todo == null)
            return NotFound();
        
        return Ok(todo);
    }

    [HttpPut("/{id:int}")]
    public TodoModel Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);

        if (model == null)
        {
            return todo;
        }

        model.Title = todo.Title;
        model.Done = todo.Done;

        context.Todos.Update(model);
        context.SaveChanges();
        return model;
    }
    
    [HttpPost("/")]
    public IActionResult Post([FromBody]TodoModel todo, [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();

        return Created($"/{todo.Id}", todo);
    }
}