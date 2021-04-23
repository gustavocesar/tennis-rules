using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;
using Domain.ValueObjects.Base;

namespace Domain.ValueObjects
{
    public class Pontuacao : ValueObjectBase
    {
        private IList<int> _sequencia = new List<int>
        {
            (int)PontuacaoEnum.PontuacaoInicial,
            (int)PontuacaoEnum.PrimeiroPonto,
            (int)PontuacaoEnum.SegundoPonto,
            (int)PontuacaoEnum.TerceiroPonto
        };
        
        public Pontuacao()
        {
            Pontos = _sequencia.First();
        }

        public int Pontos { get; private set; }

        public void Pontuar()
        {
            var next = _sequencia.Where(x => x > Pontos).FirstOrDefault();
            
            if (next != 0)
                Pontos = next;
        }
    }
}