using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Domain.Transacoes;
using LarEmDia.Infrastructure.Data;
using LarEmDia.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Repositories
{
    public class TransacaoRepository(ApplicationDbContext dbContext) : ITransacaoRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task AdicionarAsync(Transacao transacao)
        {
            await _dbContext.Transacoes.AddAsync(transacao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Transacao transacaoAtualizada)
        {
            _dbContext.Transacoes.Update(transacaoAtualizada);
            await _dbContext.SaveChangesAsync();
        }

        public Task<PagedResult<Transacao>> BuscarCategoriaPorDescricao(string descricao, PaginationParameters paginationParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Transacao> BuscarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeletarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
