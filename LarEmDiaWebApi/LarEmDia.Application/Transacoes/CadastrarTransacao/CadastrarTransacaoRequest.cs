using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Transacoes.CadastrarTransacao
{
    public record CadastrarTransacaoRequest : IRequest<BaseResult<Guid>>
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public FinalidadeEnum Finalidade { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid PessoaId { get; set; }

    }
}
