using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface IToDoService
{
    public List<ToDo> GetAll();

    public List<ToDo> SearchFor(string text);

    public ToDo GetById(int id);

    public void Edit(ToDo toDo);

    public void Add(ToDo toDo);

    public void Delete(ToDo toDo);
}