using APIDAPPERSQL.Data;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using static APIDAPPERSQL.Data.TarefaContext;

namespace APIDAPPERSQL.EndPoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoint(this WebApplication app)
        {
            app.MapGet("/", () => $" Bem Vindo a API Tarefas {DateTime.Now}");

            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();
                if (tarefas is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(tarefas);

            });

            app.MapGet("/tarefa/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                return con.Get<Tarefa>(id) is Tarefa tarefas ? Results.Ok(tarefas) :
                Results.NotFound();
            });

            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(tarefa);
                return Results.Created($"TGarefa {id},", tarefa);
            });

            app.MapPut("tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(tarefa);
                return Results.Ok();
            });

            app.MapDelete("/tarefa/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var deleted = con.Get<Tarefa>(id);
                if (deleted is null)
                {
                    Results.NotFound();
                }
                con.Delete(deleted);
                return Results.Ok(deleted);
            });

        }
    }
}
