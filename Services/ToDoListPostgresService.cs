using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public class ToDoListPostgresService : IToDoListService
{
    private readonly PostgresContext _context;

    public ToDoListPostgresService(PostgresContext context)
    {
        this._context = context;
    }

    public void Add(ToDoList toDoList)
    {
        this._context.Add(toDoList);
        this._context.SaveChanges();
    }

    public void Delete(ToDoList toDoList)
    {
        this._context.ToDoLists.Remove(toDoList);
        this._context.SaveChanges();
    }

    public void Edit(ToDoList toDoList)
    {
        ToDoList oldToDoList = this._context.ToDoLists.First(td => toDoList.Id == td.Id);

        oldToDoList.Task = toDoList.Task;
        oldToDoList.Done = toDoList.Done;

        this._context.SaveChanges();
    }

    public List<ToDoList> GetAll() => this._context.ToDoLists.ToList();

    public ToDoList GetById(int id) =>
        this._context.ToDoLists.FirstOrDefault(tdList => tdList.Id == id);

    public List<ToDoList> SearchFor(string text) =>
        this._context.ToDoLists.Where(tdList => tdList.Task.ToUpper().Contains(text.ToUpper())).ToList();
}