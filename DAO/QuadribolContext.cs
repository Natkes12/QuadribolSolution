﻿using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DAO
{
    public class QuadribolContext : DbContext
    {
        public QuadribolContext(DbContextOptions<QuadribolContext> options) : base(options)
        {

        }

        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Narrador> Narradores { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuadribolDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogo>().HasOne(j => j.Narrador).WithMany(c => c.Jogos);

            modelBuilder.Entity<JogoTime>().HasKey(c => new { c.TimeID, c.JogoID });
            modelBuilder.Entity<JogoTime>().HasOne(c => c.Jogo).WithMany(c => c.JogosTime).HasForeignKey(c => c.JogoID);
            modelBuilder.Entity<JogoTime>().HasOne(c => c.Time).WithMany(c => c.Jogos).HasForeignKey(c => c.TimeID);

            modelBuilder.Entity<Usuario>().HasIndex(c => c.Email).IsUnique(true);
            modelBuilder.Entity<Jogo>().HasIndex(c => c.DataJogo).IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
