using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.BuscarPessoaPorId
{
    public class BuscarPessoaPorIdHandler(IPessoaRepository pessoaRepository) : IRequestHandler<BuscarPessoaPorIdRequest, BaseResult<PessoaDto>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        public async Task<BaseResult<PessoaDto>> Handle(BuscarPessoaPorIdRequest request, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.BuscarPorIdAsync(request.Id);
            if (pessoa.Nome == "Pessoa não encontrada")
            {
                var badResponse = BaseResult<PessoaDto>.Erro(pessoa.Nome);
                return badResponse;
            }
            
            var pessoaDto = new PessoaDto()
            {
                Id = pessoa.Id,
                Nome = pessoa?.Nome ?? "Pessoa não encontrada",
                Idade = pessoa?.Idade ?? 0
            };

            var response = BaseResult<PessoaDto>.Sucesso(pessoaDto);
            return response;
        }
    }
}
