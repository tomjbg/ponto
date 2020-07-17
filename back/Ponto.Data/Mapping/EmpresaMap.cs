using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ponto.Domain.Models;


namespace Ponto.Data.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.RazaoSocial).HasMaxLength(250).IsRequired();
            builder.Property(m => m.NomeFantasia).HasColumnType("varchar(250)");
            builder.Property(m => m.CNPJ).HasMaxLength(14).IsRequired();
            builder.Property(m => m.IE).HasMaxLength(14);
            builder.Property(m => m.IM).HasMaxLength(14);
            builder.Property(m => m.RamoAtividade).HasColumnType("varchar(250)");

            builder.Ignore(m => m.Notifications);
            builder.Ignore(m => m.Valid);
            builder.Ignore(m => m.Invalid);
            
            builder.HasOne(m => m.EnderecoEmpresa)
                .WithOne(m => m.Empresa);

            builder.HasMany(m => m.Funcionarios)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.EmpresaId);
            
        }
    }
}
