using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDespesas.Data.Mapping;     

namespace GerenciadorDespesas.Data
{
    public class Context : DbContext
    {
        public DbSet<TipoDespesa> TipoDespesas { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Salario> Salarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DespesasMap());
            modelBuilder.ApplyConfiguration(new MesMap());
            modelBuilder.ApplyConfiguration(new SalarioMap());
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());

        }

    }
}
