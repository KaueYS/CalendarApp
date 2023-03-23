using System.Data.SqlClient;
using static APIDAPPERSQL.Data.TarefaContext;

namespace APIDAPPERSQL.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.
                GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<GetConnection>(Sp => async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });
            return builder;
        }
    }
}
