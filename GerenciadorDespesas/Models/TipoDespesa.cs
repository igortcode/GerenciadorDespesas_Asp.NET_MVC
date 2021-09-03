﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDespesas.Models
{
    public class TipoDespesa
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Preencha o campo corretamente!")]
        [StringLength(30, ErrorMessage ="Limite de caracteres excedido!")]
        public string Nome { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}