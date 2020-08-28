using System;
using System.Collections.Generic;
using System.Text;
using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Condominio> condominios { get; set; }
        public DbSet<AguaCondominio> aguaCondominios { get; set; }
        public DbSet<Apartamento> apartamentos { get; set; }
        public DbSet<AguaApartamento> aguaApartamentos { get; set; }
        
    }
}
