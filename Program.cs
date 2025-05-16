using System.Collections.Concurrent;
using TodoApi.DTOs;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();

    var method = context.Request.Method;
    var path = context.Request.Path;
    var statusCode = context.Response.StatusCode;

    Console.WriteLine($"{method} {path} responded {statusCode}");
});


var todos = new ConcurrentDictionary<Guid, TodoItem>();

app.MapGet("/todos", () => Results.Ok(todos.Values));

app.MapGet("/todos/{id:guid}", (Guid id) =>
    todos.TryGetValue(id, out var todo) ? Results.Ok(todo) : Results.NotFound()
);

app.MapPost("/todos", async (HttpContext context) =>
{
    var request = await context.Request.ReadFromJsonAsync<CreateTodoRequest>();
    if (string.IsNullOrWhiteSpace(request?.Text))
        return Results.BadRequest("Text is required");

    var item = new TodoItem(Guid.NewGuid(), request.Text, false, DateTime.UtcNow);
    todos[item.Id] = item;
    return Results.Created($"/todos/{item.Id}", item);
});

app.MapPut("/todos/{id:guid}", async (Guid id, HttpContext context) =>
{
    var request = await context.Request.ReadFromJsonAsync<UpdateTodoRequest>();
    if (!todos.TryGetValue(id, out var oldItem)) return Results.NotFound();

    var updated = oldItem with { Text = request.Text, IsComplete = request.IsComplete };
    todos[id] = updated;
    return Results.Ok(updated);
});

app.MapDelete("/todos/{id:guid}", (Guid id) =>
    todos.TryRemove(id, out _) ? Results.NoContent() : Results.NotFound()
);

app.Run();
