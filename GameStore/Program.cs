var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
// if request comes for get in the root, we will rely with this

app.Run();
