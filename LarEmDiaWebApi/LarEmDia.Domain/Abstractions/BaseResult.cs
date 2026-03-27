using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.Abstractions
{
    public record BaseResult<T>
    {
        public bool EhSucesso { get; init; }
        public string? Mensagem { get; init; }
        public T? Data { get; init; }
        public static BaseResult<T> Sucesso(T data, string? message = null) => new() { EhSucesso = true, Data = data, Mensagem = message };
        public static BaseResult<T> Erro(string error) => new() { EhSucesso = false, Mensagem = error };
    }
}
