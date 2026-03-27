using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LarEmDia.Domain.Abstractions
{
    //o código ficou em inglês, em razão de ser mais comum encontrar esse tipo de configuração em inglês,
    //entretanto os retornos de erro estão em português para manter o padrão com o resto das mensagens de erro do sistema
    public class PaginationParameters
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public PaginationParameters () { }

        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior ou igual a 1.")]
        public int PageNumber { get; set; } = 1;
        [Range(1, MaxPageSize, ErrorMessage = "A quantidade de itens da página deve ser entre 1 e 50.")]
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; } = [];
        public PaginationMetadata Metadata { get; set; } = new();
    }

    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext {  get; set; }
        public bool HasPrevious { get; set; }
    }
}
