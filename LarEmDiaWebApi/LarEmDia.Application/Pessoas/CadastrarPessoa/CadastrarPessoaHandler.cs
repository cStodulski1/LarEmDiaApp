using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.CadastrarPessoa
{
    public class CadastrarPessoaHandler(IPessoaRepository pessoaRepository) : IRequestHandler<CadastrarPessoaRequest, BaseResult<Guid>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        public async Task<BaseResult<Guid>> Handle(CadastrarPessoaRequest request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa(request.Nome, request.Idade);
            await _pessoaRepository.AdicionarAsync(pessoa);
            var response = BaseResult<Guid>.Sucesso(pessoa.Id, $"Pessoa com id: {pessoa.Id} cadastrada com sucesso.");

            return response;
        }
    }
}
