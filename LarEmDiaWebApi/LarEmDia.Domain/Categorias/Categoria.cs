using LarEmDia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.Categorias
{
    public class Categoria
    {
        public Categoria(string descricao, FinalidadeEnum finalidade = FinalidadeEnum.Despesa) 
        {
            Guid.NewGuid();
            Descricao = descricao;
            Finalidade = finalidade;
        }
        
        public Guid Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public FinalidadeEnum Finalidade { get; private set; } = FinalidadeEnum.Despesa;
    }
}
