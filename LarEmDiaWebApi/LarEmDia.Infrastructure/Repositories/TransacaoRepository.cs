using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Enums;
using LarEmDia.Domain.Extensions;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Domain.Transacoes;
using LarEmDia.Infrastructure.Data;
using LarEmDia.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Task<Transacao> BuscarPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<Transacao>> BuscarPorPessoaIdAsync(Guid pessoaId, PaginationParameters paginationParameters)
        {
            var query = _dbContext.Transacoes.Where(t => t.PessoaId == pessoaId);

            var listaDeTransacoesPaginadas = await query.ToPagedResultAsync(paginationParameters);
            return listaDeTransacoesPaginadas;
        }

        public async Task<IReadOnlyList<Transacao>> BuscarTodasAsTransacoesPorPessoaIdAsycn(Guid pessoaId)
        {
            var query = _dbContext.Transacoes.Where(t => t.PessoaId == pessoaId).AsNoTracking();

            var listaDeTransacoes = await query.ToListAsync();
            return listaDeTransacoes;
        }

        public decimal BuscarTotalReceita()
        {
            var query = _dbContext.Transacoes.Where(t => t.Finalidade == FinalidadeEnum.Receita).AsNoTracking();
            var listaDeReceitas = query.ToList();
            decimal totalDeReceita = listaDeReceitas.Sum(t => t.Valor);
            return totalDeReceita;
        }

        public decimal BuscarTotalDespesas()
        {
            var query = _dbContext.Transacoes.Where(t => t.Finalidade == FinalidadeEnum.Despesa).AsNoTracking();
            var listaDeDespesa = query.ToList();
            decimal totalDeDespesa = listaDeDespesa.Sum(t => t.Valor);
            return totalDeDespesa;
        }
    }
}
