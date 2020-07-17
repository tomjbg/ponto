using System;
using System.Collections.Generic;
using System.Text;
using Ponto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ponto.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoEmpresa>
    {
        public void Configure(EntityTypeBuilder<EnderecoEmpresa> builder)
        {
            builder.ToTable("EnderecoEmpresa");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Logradouro).HasMaxLength(250);
            builder.Property(m => m.Numero).HasMaxLength(20);
            builder.Property(m => m.Complemento).HasMaxLength(500);
            builder.Property(m => m.Bairro).HasMaxLength(50);
            builder.Property(m => m.Cidade).HasMaxLength(50);
            builder.Property(m => m.Estado).HasMaxLength(10);
            builder.Property(m => m.Pais).HasMaxLength(50);

            builder.Ignore(m => m.Notifications);
            builder.Ignore(m => m.Valid);
            builder.Ignore(m => m.Invalid);

        }

    }
}
