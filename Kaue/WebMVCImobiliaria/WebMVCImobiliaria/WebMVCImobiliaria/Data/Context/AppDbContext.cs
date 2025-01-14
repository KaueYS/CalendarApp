﻿using Microsoft.EntityFrameworkCore;
using WebMVCImobiliaria.Models;

namespace WebMVCImobiliaria.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Imovel> IMOVEIS { get; set; }
        public DbSet<ClienteImovel> CLIENTEIMOVEIS { get; set; }
        public DbSet<ClienteInteresseImovel> CLIENTEINTERESSEIMOVEIS { get; set; }
        public DbSet<ImovelDetalhe> IMOVELDETALHES { get; set; }
    }
}
