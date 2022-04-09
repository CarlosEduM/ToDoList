using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Models;

[Table("to_do_list")]
public class ToDoList
{
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("task")]
    public string Task { get; set; }
    [Column("done")]
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