using System.Collections.Generic;


namespace GerenciadorDespesas.Models
{
    public class Mes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
        public Salario Salario { get; set; }
    }
}
