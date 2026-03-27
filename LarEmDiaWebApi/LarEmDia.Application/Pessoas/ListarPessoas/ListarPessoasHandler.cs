using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using LarEmDia.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Pessoas.ListarPessoas
{
    public class ListarPessoasHandler(IPessoaRepository pessoaRepository) : IRequestHandler<ListarPessoasRequest, PagedResult<PessoaDto>>
    {
        private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
        public async Task<PagedResult<PessoaDto>> Handle(ListarPessoasRequest request, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.BuscarPessoasPorNome(request.Busca, request.PaginationParameters);
            var pessoasDtos = new List<PessoaDto>();
            foreach (var pessoa in pessoas.Data)
            {
                pessoasDtos.Add(new PessoaDto
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Idade = pessoa.Idade
                });
            }
            PagedResult<PessoaDto> pagedResult = new()
            {
                Data = pessoasDtos,
                Metadata = pessoas.Metadata
            };

            return pagedResult;

        }
    }
}
