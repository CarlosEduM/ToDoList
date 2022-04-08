using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface IToDoListService
{
    public List<ToDoList> GetAll();

    public List<ToDoList> SearchFor(string text);

    public ToDoList GetToDoListById(int id);

    public void Edit(int id, ToDoList newToDoList);

    public void Add(ToDoList newToDoList);

    public void Delete(int id);
}