using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Services;
using ToDoListAPI.Models;

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
    public ActionResult<List<ToDoList>> GetAll() => this._service.GetAll();

    [HttpPost("Search")]
    public ActionResult<List<ToDoList>> GetSearch(ToDoList search) => this._service.SearchFor(search.Task);

    [HttpPost]
    public IActionResult Create(ToDoList newToDoList)
    {
        if (newToDoList.Task == "" || newToDoList.Task == null)
        {
            return BadRequest();
        }

        this._service.Add(newToDoList);

        return CreatedAtAction(nameof(Create), new { id = newToDoList.Id }, newToDoList);
    }

}