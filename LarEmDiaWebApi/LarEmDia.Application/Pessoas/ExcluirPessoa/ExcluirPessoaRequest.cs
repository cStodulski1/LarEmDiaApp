
using LarEmDia.Domain.Abstractions;
using MediatR;
using System;

namespace LarEmDia.Application.Pessoas.ExcluirPessoa
{
    public record ExcluirPessoaRequest(Guid Id) : IRequest<BaseResult<Guid>>;
}
