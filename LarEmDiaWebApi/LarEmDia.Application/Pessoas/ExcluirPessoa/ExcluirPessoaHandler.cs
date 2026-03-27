using LarEmDia.Domain.Abstractions;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;

namespace LarEmDia.Application.Pessoas.ExcluirPessoa
{
    public class ExcluirPessoaHandler(IPessoaRepository pessoaRepository) : IRequestHandler<ExcluirPessoaRequest, BaseResult<Guid>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        public async Task<BaseResult<Guid>> Handle(ExcluirPessoaRequest request, CancellationToken cancellationToken)
        {
            await _pessoaRepository.DeletarPorId(request.Id);
            var response = BaseResult<Guid>.Sucesso(request.Id, "Pessoa excluída com sucesso!");
            return response;
        }
    }
}
