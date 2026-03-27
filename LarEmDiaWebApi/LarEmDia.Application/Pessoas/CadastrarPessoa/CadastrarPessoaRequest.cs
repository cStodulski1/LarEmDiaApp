using LarEmDia.Domain.Abstractions;
using MediatR;

namespace LarEmDia.Application.Pessoas.CadastrarPessoa
{
    public record CadastrarPessoaRequest : IRequest<BaseResult<Guid>>
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}
