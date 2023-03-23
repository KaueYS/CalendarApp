using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<TodoModel> Todos2 { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder option)
        => option.UseSqlite("DataSource=app.db;Cache=Shared");



    }
}