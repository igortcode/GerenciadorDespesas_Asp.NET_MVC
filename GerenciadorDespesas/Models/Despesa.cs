using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public int MesId { get; set; }
        public Mes Mes { get; set; }
        public int TipoDespesaId { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
        [Required(ErrorMessage ="Campo obrigatório!")]
        [Range(0, Double.MaxValue, ErrorMessage ="Valor inválido")]
        public double Valor { get; set; }
    }
}
