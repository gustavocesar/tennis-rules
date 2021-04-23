using System;
using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Game : EntityBase
    {
        //Construtor vazio, exigido pelo Entity Framework
        private Game() { }

        public Game(Jogador jogador1, Jogador jogador2)
        {
            Jogador1 = jogador1;
            PontuacaoJogador1 = new Pontuacao();
            VantagemJogador1 = false;

            Jogador2 = jogador2;
            PontuacaoJogador2 = new Pontuacao();
            VantagemJogador2 = false;
            
            Data = DateTime.Now;
            Empatado = new Empate();
        }

        public Jogador Jogador1 { get; private set; }
        public Pontuacao PontuacaoJogador1 { get; private set; }
        public bool VantagemJogador1 { get; private set; }

        public Jogador Jogador2 { get; private set; }
        public Pontuacao PontuacaoJogador2 { get; private set; }
        public bool VantagemJogador2 { get; private set; }

        public Jogador JogadorVitorioso { get; private set; }

        public DateTime Data { get; private set; }
        public Empate Empatado { get; private set; }

        public override bool IsValid()
        {
            if (Jogador1 == null) return false;
            if (Jogador2 == null) return false;

            //TODO: adicionar mensagens de validação
            
            return true;
        }

        public void PontuarJogador1()
        {
            var maximo = (int)PontuacaoEnum.TerceiroPonto;

            if (PontuacaoJogador1.Pontos == maximo && PontuacaoJogador2.Pontos < maximo)
            {
                VitoriaDe(Jogador1);
                return;
            }

            PontuacaoJogador1.Pontuar();

            if (PontuacaoJogador1.Pontos == maximo && PontuacaoJogador2.Pontos == maximo)
            {
                if (VantagemJogador1)
                {
                    VitoriaDe(Jogador1);
                    return;
                }

                Empatar();
                VantagemJogador1 = true;
                VantagemJogador2 = false;
            }
        }
        
        public void PontuarJogador2()
        {
            var maximo = (int)PontuacaoEnum.TerceiroPonto;

            if (PontuacaoJogador2.Pontos == maximo && PontuacaoJogador1.Pontos < maximo)
            {
                VitoriaDe(Jogador2);
                return;
            }

            PontuacaoJogador2.Pontuar();

            if (PontuacaoJogador2.Pontos == maximo && PontuacaoJogador1.Pontos == maximo)
            {
                if (VantagemJogador2)
                {
                    VitoriaDe(Jogador2);
                    return;
                }

                Empatar();
                VantagemJogador2 = true;
                VantagemJogador1 = false;
            }
        }

        private void VitoriaDe(Jogador jogador)
        {
            JogadorVitorioso = jogador;

            Desempatar();
        }

        public void Empatar()
        {
            Empatado.Empatar();
        }

        public void Desempatar()
        {
            Empatado.Desempatar();
        }
    }
}
