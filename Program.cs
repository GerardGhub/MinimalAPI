using MinimalAPI.Models;

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
   var content = string.Join('\n', products.Select
       (temp => temp.ToString()));

    await context.Response.WriteAsync(content);
});

app.MapPost("/products", async (HttpContext context, Products product) =>
{
    products.Add(product);
    await context.Response.WriteAsync("Product Successfully Added!");
});

app.Run();
