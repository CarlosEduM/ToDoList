using ToDoListAPI.Data;
using ToDoListAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Posgres dependence
builder.Services.AddDbContext<PostgresContext>(
    options => options.UseNpgsql(
        builder.Configuration.GetConnectionString("Postgres")
    ));
// ToDoListPostgresService dependence
builder.Services.AddScoped<IToDoListService, ToDoListPostgresService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
