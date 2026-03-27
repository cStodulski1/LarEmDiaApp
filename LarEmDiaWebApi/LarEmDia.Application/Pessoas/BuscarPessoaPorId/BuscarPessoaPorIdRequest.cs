using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.BuscarPessoaPorId
{
    public record BuscarPessoaPorIdRequest(Guid Id) : IRequest<BaseResult<PessoaDto>>;
}
