using System.Data;

namespace APIDAPPERSQL.Data;

public class TarefaContext
{
    public delegate Task<IDbConnection> GetConnection();
}
