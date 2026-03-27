using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Categorias.ListarCategoria
{
    public record ListarCategoriaRequest(string Busca, FinalidadeEnum finalidade, PaginationParameters PaginationParameters) : IRequest<PagedResult<CategoriaDto>>;

}
