using LarEmDia.Domain.DTOs;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Relatorios.PessoasTotalSumario
{
    public class PessoasTotalSumarioHandler(ITransacaoRepository transacaoRepository) : IRequestHandler<PessoasTotalSumarioRequest, TotaisDto>
    {
        private readonly ITransacaoRepository _transacaoRepository = transacaoRepository;
        public Task<TotaisDto> Handle(PessoasTotalSumarioRequest request, CancellationToken cancellationToken)
        {
            decimal totalReceita = _transacaoRepository.BuscarTotalReceita();
            decimal totalDespesa = _transacaoRepository.BuscarTotalDespesas();

            var result = new TotaisDto { TotalDeReceita = totalReceita, TotalDeDespesas = totalDespesa };
            return Task.FromResult(result);
        }
    }
}
