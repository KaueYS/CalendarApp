using CRUDMVCSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVCSQL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
