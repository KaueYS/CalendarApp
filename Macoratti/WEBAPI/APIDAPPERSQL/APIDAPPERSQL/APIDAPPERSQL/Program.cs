
using APIDAPPERSQL.EndPoints;
using APIDAPPERSQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();

var app = builder.Build();

app.MapTarefasEndpoint();

app.Run();
