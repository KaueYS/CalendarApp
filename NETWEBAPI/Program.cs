var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World2!");
app.MapGet("/user", () => "Kaue Souza");

app.Run();
