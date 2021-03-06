﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ponto.Data.Context;

namespace Ponto.Data.Migrations.PontoDB
{
    [DbContext(typeof(PontoDBContext))]
    partial class PontoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ponto.Domain.Models.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<string>("IE")
                        .HasMaxLength(14);

                    b.Property<string>("IM")
                        .HasMaxLength(14);

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RamoAtividade")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Ponto.Domain.Models.EnderecoEmpresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasMaxLength(50);

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Complemento")
                        .HasMaxLength(500);

                    b.Property<Guid>("EmpresaId");

                    b.Property<string>("Estado")
                        .HasMaxLength(10);

                    b.Property<string>("Logradouro")
                        .HasMaxLength(250);

                    b.Property<string>("Numero")
                        .HasMaxLength(20);

                    b.Property<string>("Pais")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId")
                        .IsUnique();

                    b.ToTable("EnderecoEmpresa");
                });

            modelBuilder.Entity("Ponto.Domain.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apelido");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<Guid>("EmpresaId");

                    b.Property<string>("FormaContratacao");

                    b.Property<byte[]>("FotoData");

                    b.Property<string>("FotoFilename");

                    b.Property<string>("Funcao");

                    b.Property<DateTime>("HorarioEntrada");

                    b.Property<DateTime>("HorarioSaida");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Ponto.Domain.Models.EnderecoEmpresa", b =>
                {
                    b.HasOne("Ponto.Domain.Models.Empresa", "Empresa")
                        .WithOne("EnderecoEmpresa")
                        .HasForeignKey("Ponto.Domain.Models.EnderecoEmpresa", "EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ponto.Domain.Models.Funcionario", b =>
                {
                    b.HasOne("Ponto.Domain.Models.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
