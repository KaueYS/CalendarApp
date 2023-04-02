using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebIMOBMentoria.Models;

namespace WebIMOBMentoria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Imovel> IMOVEIS { get; set; }
    }
}