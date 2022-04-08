namespace ToDoListAPI.Models;

public class ToDoList
{
    public int Id { get; set; }
    public string Task { get; set; }
    public bool Done { get; set; }


    public ToDoList()
    {
        this.Task = "";
        this.Done = false;
    }

    public ToDoList(int id, string task, bool done)
    {
        this.Id = id;
        this.Task = task;
        this.Done = done;
    }

    public ToDoList(string task)
    {
        this.Task = task;
        this.Done = false;
    }
}