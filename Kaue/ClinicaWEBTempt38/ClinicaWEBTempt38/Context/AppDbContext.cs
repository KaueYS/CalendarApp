﻿using ClinicaWEBTempt38.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClinicaWEBTempt38.Context
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

