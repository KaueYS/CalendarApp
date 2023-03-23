using Microsoft.EntityFrameworkCore;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.MapGet("/", () => "Hello World!");

app.Run();
