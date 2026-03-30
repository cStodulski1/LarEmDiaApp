using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Transacoes;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Transacoes.CadastrarTransacao
{
    public class CadastrarTransacaoHandler(ITransacaoRepository transacaoRepository, ICategoriaRepository categoriaRepository) : IRequestHandler<CadastrarTransacaoRequest, BaseResult<Guid>>
    {
        private readonly ITransacaoRepository _transacaoRepository = transacaoRepository;
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;
        public async Task<BaseResult<Guid>> Handle(CadastrarTransacaoRequest request, CancellationToken cancellationToken)
        {
            var transacao = new Transacao(request.Valor, request.Descricao, request.Finalidade, request.CategoriaId, request.PessoaId);
            var categoria = await _categoriaRepository.BuscarPorIdAsync(request.CategoriaId);

            if (categoria.Finalidade != request.Finalidade)
            {
                return BaseResult<Guid>.Erro("A finalidade da transação deve ser compatível com a finalidade da categoria.");
            }

            await _transacaoRepository.AdicionarAsync(transacao);

            var response = BaseResult<Guid>.Sucesso(transacao.Id, "Transação cadastrada com sucesso!");

            return response;
        }
    }
}
