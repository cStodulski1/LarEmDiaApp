using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.ListarPessoas
{
    public record ListarPessoasRequest(string Busca, PaginationParameters PaginationParameters) : IRequest<PagedResult<PessoaDto>>;
}
