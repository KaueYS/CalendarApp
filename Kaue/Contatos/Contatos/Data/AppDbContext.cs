using Contatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Contatos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet <ContatoModel> CONTATOS { get; set; }

    }
}
