using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GerenciadorDespesas.Data.Mapping
{
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Valor).IsRequired();

            builder.HasOne(s => s.Mes).WithOne(s => s.Salario).HasForeignKey<Salario>(s => s.MesId);
            builder.ToTable("Salarios");
        }
    }
}
