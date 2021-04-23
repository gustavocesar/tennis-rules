using System;
using Domain.Entities.Base;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Jogador : EntityBase
    {
        //Construtor vazio, exigido pelo Entity Framework
        private Jogador() { }
        
        public Jogador(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public override bool IsValid()
        {
            if (String.IsNullOrEmpty(Nome)) return false;

            //TODO: adicionar as mensagens de validação

            return true;
        }
    }
}