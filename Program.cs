using MinimalAPI.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Products> products = new List<Products>()
{
    new Products() { Id = 1, ProductName = "Iphone"},
    new Products() {Id = 2, ProductName = "Oppo"}

};

//GET PRODUCTS
app.MapGet("/products", async (HttpContext context) =>
{
    await context.Response.WriteAsync(JsonSerializer.Serialize(products));
});

        //GET /products/{id}
        app.MapGet("products/{id:int}", async (HttpContext context, int id) =>
        {
        Products? product = products.FirstOrDefault(temp =>
        temp.Id == id);
        if (product == null)
        {
         context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Incorrect Product Id");
         return;
        }
            await context.Response.WriteAsync(JsonSerializer.Serialize(product));
        });


//POST
app.MapPost("/products", async (HttpContext context, Products product) =>
{
    products.Add(product);
    await context.Response.WriteAsync("Product Successfully Added!");
});

app.Run();
