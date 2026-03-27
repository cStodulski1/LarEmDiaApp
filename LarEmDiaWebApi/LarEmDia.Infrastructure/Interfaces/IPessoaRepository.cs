using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Interfaces
{
    public interface IPessoaRepository
    {
        public Task AdicionarAsync(Pessoa pessoa);
        public Task<Pessoa> BuscarPorIdAsync(Guid id);
        public Task<PagedResult<Pessoa>> BuscarPessoasPorNome(string busca, PaginationParameters paginationParameters);
        public Task AtualizarAsync(Pessoa pessoa);
        public Task DeletarPorId(Guid id);
    }
}
