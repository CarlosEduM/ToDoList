using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Models;

[Table("to_do_list")]
public class ToDo
{
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("task")]
    public string Task { get; set; }
    [Column("done")]
    public bool Done { get; set; }


    public ToDo()
    {
        this.Task = "";
        this.Done = false;
    }

    public ToDo(int id, string task, bool done)
    {
        this.Id = id;
        this.Task = task;
        this.Done = done;
    }

    public ToDo(string task)
    {
        this.Task = task;
        this.Done = false;
    }
}