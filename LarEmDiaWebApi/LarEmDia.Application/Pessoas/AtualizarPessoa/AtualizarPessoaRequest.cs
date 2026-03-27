using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;

namespace LarEmDia.Application.Pessoas.AtualizarPessoa
{
    public record AtualizarPessoaRequest : IRequest<BaseResult<PessoaDto>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}
