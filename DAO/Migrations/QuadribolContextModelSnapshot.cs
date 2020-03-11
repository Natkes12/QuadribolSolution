﻿// <auto-generated />
using System;
using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAO.Migrations
{
    [DbContext(typeof(QuadribolContext))]
    partial class QuadribolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("int")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("TimeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TimeID");

                    b.ToTable("Competidores");
                });

            modelBuilder.Entity("Entity.Jogo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataJogo")
                        .HasColumnType("datetime2")
                        .IsUnicode(false);

                    b.Property<bool>("Encerrado")
                        .HasColumnType("bit");

                    b.Property<int>("NarradorID")
                        .HasColumnType("int");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("int");

                    b.Property<int>("Time1ID")
                        .HasColumnType("int");

                    b.Property<int>("Time2ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NarradorID");

                    b.HasIndex("Time1ID");

                    b.HasIndex("Time2ID");

                    b.ToTable("Jogos");
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
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.ToTable("Narradores");
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

                    b.ToTable("Times");
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
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entity.Competidor", b =>
                {
                    b.HasOne("Entity.Time", null)
                        .WithMany("Competidor")
                        .HasForeignKey("TimeID");
                });

            modelBuilder.Entity("Entity.Jogo", b =>
                {
                    b.HasOne("Entity.Narrador", "Narrador")
                        .WithMany("Jogos")
                        .HasForeignKey("NarradorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Time", "Time1")
                        .WithMany("Jogos")
                        .HasForeignKey("Time1ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Time", "Time2")
                        .WithMany()
                        .HasForeignKey("Time2ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
