using ClinicaWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaWEB.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Paciente> PACIENTES { get; set; }
        public DbSet<Procedimento> PROCEDIMENTOS { get; set; }
        
    }
}


        // Conn Balta
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlServer("Data Source=KAUE\\SQLEXPRESS; Initial Catalog=Blog;Integrated Security=true");
