var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
    await context.Response.WriteAsync("GET - DATA");
});

app.MapPost("/", async (HttpContext context) =>
{
    await context.Response.WriteAsync("POST - DATA");
});

app.Run();
