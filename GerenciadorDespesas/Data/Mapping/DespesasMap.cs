using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Data.Mapping
{
    public class DespesasMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Valor).IsRequired();

            builder.HasOne(d => d.Mes).WithMany(d => d.Despesas).HasForeignKey(d => d.MesId);
            builder.HasOne(d => d.TipoDespesa).WithMany(d => d.Despesas).HasForeignKey(d => d.TipoDespesaId);

            builder.ToTable("Despesas");
        }
    }
}
