using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data;

public class PostgresContext : DbContext
{
    public DbSet<ToDoList> ToDoLists { get; set; }

    public PostgresContext(DbContextOptions<PostgresContext> options) 
        : base(options)
    {
    }
}