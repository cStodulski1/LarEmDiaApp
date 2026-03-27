using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Domain.Pessoas
{
    public class Pessoa
    {
        public Pessoa(string nome, int idade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public int Idade { get; private set; }

        public void AtualizarPessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

    }
}
