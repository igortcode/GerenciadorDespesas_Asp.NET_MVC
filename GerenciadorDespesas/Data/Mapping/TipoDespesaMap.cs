using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Data.Mapping
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder)
        {
            builder.HasKey(td => td.Id);
            builder.Property(td => td.Nome).HasMaxLength(50).IsRequired();
            builder.HasMany(td => td.Despesas).WithOne(td => td.TipoDespesa).HasForeignKey(td => td.TipoDespesaId);
            builder.ToTable("TipoDespesas");
        }
    }
}
