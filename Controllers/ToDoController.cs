using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Services;
using ToDoListAPI.Models;
using System.Text.Json;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;

    public ToDoController(IToDoService service)
    {
        this._service = service;
    }

    [HttpGet]
    public ActionResult<List<ToDo>> GetAll([FromQuery] string? search)
    {
        if (search != null && search != "") 
        {
            return this._service.SearchFor(search);
        }
        
        return this._service.GetAll();
    }

    [HttpPost]
    public IActionResult Create(ToDo newToDo)
    {
        this._service.Add(newToDo);

        return CreatedAtAction(nameof(Create), new { id = newToDo.Id }, newToDo);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, ToDo editedToDo)
    {
        if (editedToDo.Id != id)
            return BadRequest();

        ToDo toDo = this._service.GetById(id);

        if (toDo is null)
            return NotFound();

        this._service.Edit(editedToDo);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ToDo toDo = this._service.GetById(id);

        if (toDo is null)
            return NotFound();

        this._service.Delete(toDo);

        return NoContent();
    }
}