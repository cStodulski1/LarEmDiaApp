using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.DTOs
{
    public class PessoaTotaisDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public bool EhMaiorDeIdade => Idade > 18;
        public decimal ValorReceita { get; set; }
        public decimal ValorDespesa { get; set; }
        public decimal Saldo => ValorReceita - ValorDespesa;

    }
}
