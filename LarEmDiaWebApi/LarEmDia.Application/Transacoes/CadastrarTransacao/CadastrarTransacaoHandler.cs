using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Transacoes;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Transacoes.CadastrarTransacao
{
    public class CadastrarTransacaoHandler(ITransacaoRepository transacaoRepository) : IRequestHandler<CadastrarTransacaoRequest, BaseResult<Guid>>
    {
        private readonly ITransacaoRepository _transacaoRepository = transacaoRepository;
        public async Task<BaseResult<Guid>> Handle(CadastrarTransacaoRequest request, CancellationToken cancellationToken)
        {
            var transacao = new Transacao(request.Valor, request.Descricao, request.Finalidade, request.CategoriaId, request.PessoaId);
            await _transacaoRepository.AdicionarAsync(transacao);

            var response = BaseResult<Guid>.Sucesso(transacao.Id);

            return response;
        }
    }
}
