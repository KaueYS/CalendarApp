using ClinicaWebEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaWebEF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        } 

        public DbSet<Procedimento> PROCEDIMENTOS { get; set; }
        public DbSet<Paciente> PACIENTES { get; set; }
    }
}
