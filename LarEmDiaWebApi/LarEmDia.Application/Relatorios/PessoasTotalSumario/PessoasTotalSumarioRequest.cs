using LarEmDia.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Relatorios.PessoasTotalSumario
{
    public record PessoasTotalSumarioRequest : IRequest<TotaisDto>;
}
