using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ponto.Domain.Models;
using Ponto.Data.Mapping;
using Ponto.Data.Identities;
using Microsoft.AspNetCore.Identity;

namespace Ponto.Data.Context
{
    public class PontoDBContext : DbContext
    {
        public PontoDBContext(DbContextOptions<PontoDBContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EnderecoEmpresa> EnderecoEmpresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
