using DAO.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DAO
{
    public class QuadribolContext : DbContext
    {

        public QuadribolContext(DbContextOptions<QuadribolContext> options):base(options)
        {

        }

        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Narrador> Narradores { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Jogo>().HasOne(j => j.Time1).WithMany(c => c.Jogos);
            modelBuilder.Entity<Jogo>().HasOne(j => j.Narrador).WithMany(c => c.Jogos);

            base.OnModelCreating(modelBuilder);
        }
    }
}
