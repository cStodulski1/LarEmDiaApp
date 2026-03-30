using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Transacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Interfaces
{
    public interface ITransacaoRepository
    {
        public Task AdicionarAsync(Transacao transacao);
        public Task<Transacao> BuscarPorIdAsync(Guid id);
        public Task<PagedResult<Transacao>> BuscarPorPessoaIdAsync(Guid pessoaId, PaginationParameters paginationParameters);
        public Task<IReadOnlyList<Transacao>> BuscarTodasAsTransacoesPorPessoaIdAsycn(Guid pessoaId);
        public decimal BuscarTotalReceita();
        public decimal BuscarTotalDespesas();
    }
}
