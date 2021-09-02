using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class Salario
    {
        public int Id { get; set; }
        public int MesId { get; set; }
        public Mes Mes { get; set; }
        [Required(ErrorMessage ="Campo obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage ="Valor inválido!")]
        public double Valor { get; set; }

    }
}
