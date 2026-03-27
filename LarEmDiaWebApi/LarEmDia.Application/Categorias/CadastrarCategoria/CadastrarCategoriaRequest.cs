using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Application.Categorias.CadastrarCategoria
{
    public record CadastrarCategoriaRequest : IRequest<BaseResult<Guid>>
    {
        public string Descricao { get; set; } = string.Empty;
        public FinalidadeEnum Finalidade { get; set; }
    }
}
