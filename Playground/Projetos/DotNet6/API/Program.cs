using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/user", () => new { Name = "Jo�o C�cero Vicente Sousa", Age = 27 });
app.MapGet("/header", (HttpResponse response) => response.Headers.Add("Teste", "Jo�o"));
app.MapPost("/", (Product product) => product);
app.MapGet("/{id}", (string id) => id);
app.MapGet("/getProduct", ([FromQuery] string dateStarte, [FromQuery] string dateEnd) => dateStarte + dateEnd);
app.Run();

public class Product
{
    public string? Code { get; set; }
    public string? Name { get; set; }
}