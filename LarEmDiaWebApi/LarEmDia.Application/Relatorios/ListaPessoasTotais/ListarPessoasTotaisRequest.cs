using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Relatorios.ListaPessoasTotais
{
    public record ListarPessoasTotaisRequest(PaginationParameters PaginationParameters) : IRequest<PagedResult<PessoaTotaisDto>>;
}
