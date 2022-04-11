using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Services;
using ToDoListAPI.Models;
using System.Text.Json;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController : ControllerBase
{
    private readonly IToDoListService _service;

    public ToDoListController(IToDoListService service)
    {
        this._service = service;
    }

    [HttpGet]
    public ActionResult<List<ToDoList>> GetAll([FromQuery] string? search)
    {
        if (search != null && search != "") 
        {
            return this._service.SearchFor(search);
        }
        
        return this._service.GetAll();
    }

    [HttpPost]
    public IActionResult Create(ToDoList newToDoList)
    {
        this._service.Add(newToDoList);

        return CreatedAtAction(nameof(Create), new { id = newToDoList.Id }, newToDoList);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, ToDoList editedToDoList)
    {
        if (editedToDoList.Id != id)
            return BadRequest();

        ToDoList toDoList = this._service.GetById(id);

        if (toDoList is null)
            return NotFound();

        this._service.Edit(editedToDoList);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ToDoList toDoList = this._service.GetById(id);

        if (toDoList is null)
            return NotFound();

        this._service.Delete(toDoList);

        return NoContent();
    }
}