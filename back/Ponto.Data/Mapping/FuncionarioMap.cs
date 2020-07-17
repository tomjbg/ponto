using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ponto.Domain.Models;

namespace Ponto.Data.Mapping
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.NomeCompleto).HasMaxLength(150).IsRequired();
            builder.Property(m => m.HorarioEntrada).IsRequired();
            builder.Property(m => m.HorarioSaida).IsRequired();

            builder.Ignore(m => m.Invalid);
            builder.Ignore(m => m.Valid);
            builder.Ignore(m => m.Notifications);
            

        }
    }
}
