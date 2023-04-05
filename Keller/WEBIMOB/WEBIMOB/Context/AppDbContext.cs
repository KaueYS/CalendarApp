using Microsoft.EntityFrameworkCore;
using WEBIMOB.Models;


namespace WEBIMOB.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options ) { }


        public DbSet<ClienteImovel> CLIENTESIMOVEIS { get; set; }


        

    }
}
