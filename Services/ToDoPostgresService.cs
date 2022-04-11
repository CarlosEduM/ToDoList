using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public class ToDoPostgresService : IToDoService
{
    private readonly PostgresContext _context;

    public ToDoPostgresService(PostgresContext context)
    {
        this._context = context;
    }

    public void Add(ToDo toDo)
    {
        this._context.Add(toDo);
        this._context.SaveChanges();
    }

    public void Delete(ToDo toDo)
    {
        this._context.ToDoList.Remove(toDo);
        this._context.SaveChanges();
    }

    public void Edit(ToDo toDo)
    {
        ToDo oldToDo = this._context.ToDoList.First(td => toDo.Id == td.Id);

        oldToDo.Task = toDo.Task;
        oldToDo.Done = toDo.Done;

        this._context.SaveChanges();
    }

    public List<ToDo> GetAll() => this._context.ToDoList.ToList();

    public ToDo GetById(int id) =>
        this._context.ToDoList.FirstOrDefault(td => td.Id == id);

    public List<ToDo> SearchFor(string text) =>
        this._context.ToDoList.Where(td => td.Task.ToUpper().Contains(text.ToUpper())).ToList();
}