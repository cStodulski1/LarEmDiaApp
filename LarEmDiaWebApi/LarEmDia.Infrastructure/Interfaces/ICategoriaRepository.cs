using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Categorias;
using LarEmDia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task AdicionarAsync(Categoria categoria);
        public Task<Categoria> BuscarPorIdAsync(Guid id);
        public Task<PagedResult<Categoria>> BuscarListaCategorias(string descricao, FinalidadeEnum finalidade, PaginationParameters paginationParameters);
        public Task AtualizarAsync(Categoria categoria);
        public Task DeletarPorId(Guid id);
    }
}
