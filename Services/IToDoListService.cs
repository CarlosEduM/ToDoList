using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface IToDoListService
{
    public List<ToDoList> GetAll();

    public List<ToDoList> SearchFor(string text);

    public ToDoList GetById(int id);

    public void Edit(ToDoList toDoList);

    public void Add(ToDoList toDoList);

    public void Delete(ToDoList toDoList);
}