using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Domain.Enums;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Relatorios.ListaPessoasTotais
{
    public class ListarPessoasTotaisHandler(IPessoaRepository pessoaRepository, ITransacaoRepository transacaoRepository) : IRequestHandler<ListarPessoasTotaisRequest, PagedResult<PessoaTotaisDto>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        private readonly ITransacaoRepository _transacaoRepository = transacaoRepository;
        public async Task<PagedResult<PessoaTotaisDto>> Handle(ListarPessoasTotaisRequest request, CancellationToken cancellationToken)
        {

            var listaPessoaTotaisDto = new List<PessoaTotaisDto>();

            var listaPessoaPaginada = await _pessoaRepository.BuscarPessoasPorNome("", request.PaginationParameters);
            foreach (var pessoa in listaPessoaPaginada.Data)
            {
                decimal valorTotalDespesa = 0;
                decimal valorTotalReceita = 0;

                var transacoesPessoa = await _transacaoRepository.BuscarTodasAsTransacoesPorPessoaIdAsycn(pessoa.Id);

                valorTotalDespesa += transacoesPessoa
                    .Where(t => t.Finalidade is FinalidadeEnum.Despesa)
                    .Sum(t => t.Valor);

                valorTotalReceita += transacoesPessoa
                    .Where(t => t.Finalidade is FinalidadeEnum.Receita)
                    .Sum(t => t.Valor);

                listaPessoaTotaisDto.Add(new PessoaTotaisDto
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Idade = pessoa.Idade,
                    ValorDespesa = valorTotalDespesa,
                    ValorReceita = valorTotalReceita
                });              
            }

            var result = new PagedResult<PessoaTotaisDto>
            {
                Data = listaPessoaTotaisDto,
                Metadata = listaPessoaPaginada.Metadata
            };

            return result;
        }
    }
}
