using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Categorias;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Categorias.CadastrarCategoria
{
    public class CadastrarCategoriaHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<CadastrarCategoriaRequest, BaseResult<Guid>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;
        public async Task<BaseResult<Guid>> Handle(CadastrarCategoriaRequest request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(request.Descricao, request.Finalidade);
            await _categoriaRepository.AdicionarAsync(categoria);

            return BaseResult<Guid>.Sucesso(categoria.Id, $"Categoria com {categoria.Id} cadastrada com sucesso.");
        }
    }
}
