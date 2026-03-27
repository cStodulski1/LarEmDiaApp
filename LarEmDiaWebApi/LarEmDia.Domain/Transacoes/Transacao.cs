using LarEmDia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.Transacoes
{
    public class Transacao
    {
        public Transacao(decimal valor, string descricao, FinalidadeEnum finalidade, Guid categoriaId, Guid pessoaId)
        {
            Id = Guid.NewGuid();
            Data = DateTime.UtcNow;
            Valor = valor;
            Descricao = descricao;
            Finalidade = finalidade;
            CategoriaId = categoriaId;
            PessoaId = pessoaId;
        }
        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public FinalidadeEnum Finalidade { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public Guid CategoriaId { get; private set; }
        public Guid PessoaId { get; private set; }
    }
}
