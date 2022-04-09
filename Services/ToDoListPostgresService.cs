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

    public void Add(ToDoList newToDoList)
    {
        this._context.Add(newToDoList);
        this._context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Edit(int id, ToDoList newToDoList)
    {
        throw new NotImplementedException();
    }

    public List<ToDoList> GetAll() => this._context.ToDoLists.ToList();

    public ToDoList GetToDoListById(int id)
    {
        throw new NotImplementedException();
    }

    public List<ToDoList> SearchFor(string text) =>
        this._context.ToDoLists.Where(tdList => tdList.Task.ToUpper().Contains(text.ToUpper())).ToList();
}