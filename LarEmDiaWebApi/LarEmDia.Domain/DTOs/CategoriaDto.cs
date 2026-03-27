using LarEmDia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.DTOs
{
    public class CategoriaDto
    {
        public Guid CategoriaId { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Finalidade { get; set; } = "Despesa";
    }
}
