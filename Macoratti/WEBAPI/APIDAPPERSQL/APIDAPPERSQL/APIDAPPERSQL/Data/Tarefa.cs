using Dapper.Contrib.Extensions;

namespace APIDAPPERSQL.Data;

[Table("Tarefas")]
public record Tarefa(int Id, string Atividade, String Status);

