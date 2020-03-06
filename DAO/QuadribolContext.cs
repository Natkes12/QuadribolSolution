using Entity;
using Microsoft.EntityFrameworkCore;
using System;

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
    }
}
