using Imobiliaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Imovel> IMOVEIS { get; set; }
    }
}
