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
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Edit(int id, ToDoList newToDoList)
    {
        throw new NotImplementedException();
    }

    public List<ToDoList> GetAll()
    {
        List<ToDoList> toDoList = this._context.ToDoLists.ToList();

        return toDoList;
    }

    public ToDoList GetToDoListById(int id)
    {
        throw new NotImplementedException();
    }

    public List<ToDoList> SearchFor(string text)
    {
        throw new NotImplementedException();
    }
}