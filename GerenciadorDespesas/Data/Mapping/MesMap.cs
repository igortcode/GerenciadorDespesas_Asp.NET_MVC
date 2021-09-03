using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Data.Mapping
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).ValueGeneratedNever();
            builder.Property(m => m.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(m => m.Despesas).WithOne(m => m.Mes).HasForeignKey(m => m.MesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Salario).WithOne(m => m.Mes).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Meses");
        }
    }
}
