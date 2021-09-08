using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class Salario
    {
        public int Id { get; set; }
        [Display(Name = "Mês")]
        public int MesId { get; set; }
        [Display(Name = "Mês")]
        public Mes Mes { get; set; }
        [Required(ErrorMessage ="Campo obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage ="Valor inválido!")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Valor { get; set; }

    }
}
