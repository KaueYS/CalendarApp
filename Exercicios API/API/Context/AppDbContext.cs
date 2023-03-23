using API.DTO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }


        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Code).HasMaxLength(30).IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Description).HasMaxLength(300);
            builder.Entity<Category>()
                .ToTable("Categories");
        }

    }



}
