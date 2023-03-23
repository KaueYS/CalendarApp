using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItemModel> CarrinhoCompraItens { get; set; }
    }
}
