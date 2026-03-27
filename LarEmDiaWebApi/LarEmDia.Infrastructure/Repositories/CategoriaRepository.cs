using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Categorias;
using LarEmDia.Domain.Enums;
using LarEmDia.Domain.Extensions;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Infrastructure.Data;
using LarEmDia.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Repositories
{
    public class CategoriaRepository(ApplicationDbContext dbContext) : ICategoriaRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task AdicionarAsync(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Categoria categoria)
        {
            _dbContext.Categorias.Update(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Categoria>> BuscarListaCategorias(string busca, FinalidadeEnum finalidade, PaginationParameters paginationParameters)
        {
            var query = _dbContext.Categorias.AsNoTracking().AsQueryable();
            if(finalidade != FinalidadeEnum.Ambas)
            {
                query = query.Where(c => c.Finalidade == finalidade);
            }
            if (!string.IsNullOrEmpty(busca))
            {
                query = query.Where(c => c.Descricao.ToLower().Contains(busca.ToLower()))
                    .OrderBy(c => c.Descricao);
            }

            var listaCategoriasPaginadas = await query.ToPagedResultAsync(paginationParameters);
            return listaCategoriasPaginadas;
        }

        public async Task<Categoria> BuscarPorIdAsync(Guid id)
        {
            try
            {
                var categoria = await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
                if (categoria == null)
                {
                    return new Categoria("Categoria não encontrada");
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar categoria por id '{id}'.", ex);
            }
        }

        public async Task DeletarPorId(Guid id)
        {
            try
            {
                var categoria = await _dbContext.Categorias.FirstOrDefaultAsync(p => p.Id == id);
                if (categoria is null) return;

                _dbContext.Categorias.Remove(categoria);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar pessoa '{id}'.", ex);
            }
        }
    }
}
