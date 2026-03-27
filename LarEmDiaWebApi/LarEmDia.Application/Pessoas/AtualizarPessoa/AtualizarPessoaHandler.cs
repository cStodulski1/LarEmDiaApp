using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.AtualizarPessoa
{
    public class AtualizarPessoaHandler(IPessoaRepository pessoaRepository) : IRequestHandler<AtualizarPessoaRequest, BaseResult<PessoaDto>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        public async Task<BaseResult<PessoaDto>> Handle(AtualizarPessoaRequest request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.BuscarPorIdAsync(request.Id);
            if (pessoa.Nome == "Pessoa não encontrada")
            {
                var badResponse = BaseResult<PessoaDto>.Erro("Pessoa não encontrada");
                return badResponse;
            }

            var pessoaDto = new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade
            };

            pessoa.AtualizarPessoa(request.Nome, request.Idade);
            await _pessoaRepository.AtualizarAsync(pessoa);

            var response = BaseResult<PessoaDto>.Sucesso(pessoaDto, "Pessoa atualizada com sucesso");

            return response;    
        }
    }
}
