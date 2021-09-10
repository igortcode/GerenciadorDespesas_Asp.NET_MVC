using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models.ViewModels
{
    public class Estatisticas
    {
        public int QuantidadeDespesas { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double MenorDespesa { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double MaiorDespesa { get; set; }
    }
}
