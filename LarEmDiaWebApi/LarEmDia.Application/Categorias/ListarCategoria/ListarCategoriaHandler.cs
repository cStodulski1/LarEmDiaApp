using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LarEmDia.Application.Categorias.ListarCategoria
{
    public class ListarCategoriaHandler(ICategoriaRepository categoriaRepository) : IRequestHandler<ListarCategoriaRequest, PagedResult<CategoriaDto>>
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;
        public async Task<PagedResult<CategoriaDto>> Handle(ListarCategoriaRequest request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.BuscarListaCategorias(request.Busca, request.finalidade, request.PaginationParameters);

            var categoriasDtos = new List<CategoriaDto>();
            foreach (var categoria in categorias.Data)
            {
                categoriasDtos.Add(new CategoriaDto
                { 
                    CategoriaId = categoria.Id,
                    Descricao = categoria.Descricao,
                    Finalidade = categoria.Finalidade.ToString(),
                });
            }

            PagedResult<CategoriaDto> pagedResult = new()
            {
                Data = categoriasDtos,
                Metadata = categorias.Metadata
            };

            return pagedResult;
        }
    }
}
