using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using GestorGaleria.Domain;
using Microsoft.EntityFrameworkCore;

namespace gestor.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Galeria> Galerias { get; set; }

        public DbSet<Tipos> Tipos { get; set; }

        public DbSet<Concessoes> Concessoes { get; set; }

/* -- 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Galeria>().HasKey(m => m.Id);
            modelBuilder.Entity<Tipos>().HasKey(m => m.Id);
            modelBuilder.Entity<Concessoes>().HasKey(m => m.Id);
        } */
    }  
} 