using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Extensions;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Infrastructure.Data;
using LarEmDia.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LarEmDia.Infrastructure.Repositories
{
    public class PessoaRepository(ApplicationDbContext dbContext) : IPessoaRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task AdicionarAsync(Pessoa pessoa)
        {
            try
            {
                await _dbContext.Pessoas.AddAsync(pessoa);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar pessoa.", ex);
            }
        }

        public async Task AtualizarAsync(Pessoa pessoa)
        {
            try
            {
                _dbContext.Pessoas.Update(pessoa);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pessoa.", ex);
            }
        }

        public async Task<Pessoa> BuscarPorIdAsync(Guid id)
        {
            try
            {
                var pessoa = await _dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
                if (pessoa == null) 
                {
                    return new Pessoa("Pessoa não encontrada", 0);
                }
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pessoa por id '{id}'.", ex);
            }
        }

        public async Task<PagedResult<Pessoa>> BuscarPessoasPorNome(string busca, PaginationParameters paginationParameters)
        {
            try
            {
                var query = _dbContext.Pessoas.AsNoTracking().AsQueryable();
                if (!string.IsNullOrEmpty(busca))
                {
                    //aqui eu coloco pra pesquisar o nome em lowercase pra caso o usuário acabe digitando sem prestar atenção nas letras maiúsculas.
                    query = query.Where(p => p.Nome.ToLower().Contains(busca.ToLower()))
                        .OrderBy(p => p.Nome);
                }

                var listaDePessoasPaginada = await query.ToPagedResultAsync(paginationParameters);
                return listaDePessoasPaginada;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer a busca.", ex);
            }
        }

        public async Task DeletarPorId(Guid id)
        {
            try
            {
                var entity = await _dbContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
                if (entity is null) return;

                _dbContext.Pessoas.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar pessoa '{id}'.", ex);
            }
        }
    }
}
