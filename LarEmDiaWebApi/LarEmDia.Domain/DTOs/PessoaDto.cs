using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.DTOs
{
    public class PessoaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}
