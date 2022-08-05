using Playground.Minimal.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", async (HttpContext context, TodoService todoService) =>
{
    var result = todoService.SayHello();
    
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync(result);
}).WithName("hello");

app.MapGet("/todos", (TodoService todoService) =>
{
    var todoItemsCollection = todoService.GetTodoItems();

    return Results.Ok(todoItemsCollection);
}).WithName("todos");

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program { }
#pragma warning restore CA1050 // Declare types in namespaces
