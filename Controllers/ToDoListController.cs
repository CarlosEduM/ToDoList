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

}