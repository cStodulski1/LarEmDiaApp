using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.DTOs
{
    public class TotaisDto
    {
        public decimal TotalDeReceita { get; set; }
        public decimal TotalDeDespesas { get; set; }
        public decimal SaldoLiquido => TotalDeReceita - TotalDeDespesas;
    }
}
