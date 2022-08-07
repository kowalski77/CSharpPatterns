using Microsoft.EntityFrameworkCore;
using Playground.Minimal.API;
using Playground.Minimal.API.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<ProductsService>();

builder.Services.AddDbContext<ProductsContext>(options =>
{
    options.UseSqlite("Filename=ProductsDatabase.db");
});

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

app.MapGet("/products", async (ProductsService productService) =>
{
    var products = await productService.GetAllProductsAsync();
    return Results.Ok(products);
}).WithName("get-products");

app.MapPost("/products", async (ProductsService productService, Product product) =>
{
    var newlyProduct = await productService.AddAsync(product);
    return Results.Ok(newlyProduct);
    
}).WithName("post-product");

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
public partial class Program { }
#pragma warning restore CA1050 // Declare types in namespaces
