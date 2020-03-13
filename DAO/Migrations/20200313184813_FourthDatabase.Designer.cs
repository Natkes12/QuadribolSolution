﻿// <auto-generated />
using System;
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations
{
    [DbContext(typeof(QuadribolContext))]
    [Migration("20200313184813_FourthDatabase")]
    partial class FourthDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Competidor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Casa")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Escolaridade")
                        .HasColumnType("int");

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("ID");

                    b.ToTable("COMPETIDORES");
                });

            modelBuilder.Entity("Entity.Jogo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataJogo")
                        .HasColumnType("DATETIME2");

                    b.Property<bool>("Encerrado")
                        .HasColumnType("bit");

                    b.Property<int>("NarradorID")
                        .HasColumnType("int");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DataJogo")
                        .IsUnique();

                    b.HasIndex("NarradorID");

                    b.ToTable("JOGOS");
                });

            modelBuilder.Entity("Entity.JogoTime", b =>
                {
                    b.Property<int>("TimeID")
                        .HasColumnType("int");

                    b.Property<int>("JogoID")
                        .HasColumnType("int");

                    b.HasKey("TimeID", "JogoID");

                    b.HasIndex("JogoID");

                    b.ToTable("JOGO_TIME");
                });

            modelBuilder.Entity("Entity.Narrador", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("ID");

                    b.ToTable("NARRADORES");
                });

            modelBuilder.Entity("Entity.Time", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Casa")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("TIMES");
                });

            modelBuilder.Entity("Entity.TimeCompetidor", b =>
                {
                    b.Property<int>("TimeID")
                        .HasColumnType("int");

                    b.Property<int>("CompetidorID")
                        .HasColumnType("int");

                    b.HasKey("TimeID", "CompetidorID");

                    b.HasIndex("CompetidorID");

                    b.ToTable("TIME_COMPETIDOR");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("Entity.Jogo", b =>
                {
                    b.HasOne("Entity.Narrador", "Narrador")
                        .WithMany("Jogos")
                        .HasForeignKey("NarradorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.JogoTime", b =>
                {
                    b.HasOne("Entity.Jogo", "Jogo")
                        .WithMany("JogosTime")
                        .HasForeignKey("JogoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Time", "Time")
                        .WithMany("Jogos")
                        .HasForeignKey("TimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.TimeCompetidor", b =>
                {
                    b.HasOne("Entity.Competidor", "Competidor")
                        .WithMany("Time")
                        .HasForeignKey("CompetidorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Time", "Time")
                        .WithMany("TimeCompetidores")
                        .HasForeignKey("TimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
