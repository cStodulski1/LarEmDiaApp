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
        public Task<PagedResult<Transacao>> BuscarCategoriaPorDescricao(string descricao, PaginationParameters paginationParameters);
        public Task AtualizarAsync(Transacao transacaoAtualizada);
        public Task DeletarPorId(Guid id);
    }
}
