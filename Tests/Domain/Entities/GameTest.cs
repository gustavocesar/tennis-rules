using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Enums;

namespace Tests.Domain.Entities
{
    [TestClass]
    public class GameTest
    {
        private Jogador _jogador1;
        private Jogador _jogador2;
        private Game _game;

        public GameTest()
        {
            _jogador1 = new Jogador("Jogador 1");
            _jogador2 = new Jogador("Jogador 2");
            _game = new Game(_jogador1, _jogador2);
        }

        [TestMethod]
        public void TestConstrutores()
        {
            //Game inválido
            var game = new Game(null, null);

            Assert.IsFalse(game.IsValid());
        }

        [TestMethod]
        public void TestPontuacaoExcedida()
        {
            _game.PontuarJogador1(); //15 pontos
            _game.PontuarJogador1(); //30 pontos
            _game.PontuarJogador1(); //40 pontos (pontuação máxima)
            _game.PontuarJogador1();

            Assert.IsTrue(_game.PontuacaoJogador1.Pontos == (int)PontuacaoEnum.TerceiroPonto);
        }

        [TestMethod]
        public void TestFalhaDePontuacao()
        {
            _game.PontuarJogador1();

            Assert.IsFalse(_game.PontuacaoJogador1.Pontos <= (int)PontuacaoEnum.PontuacaoInicial);
            Assert.IsTrue(_game.PontuacaoJogador1.Pontos == (int)PontuacaoEnum.PrimeiroPonto);
        }

        [TestMethod]
        public void TestVitoriaJogador1()
        {
            _game.PontuarJogador1(); //15 pontos
            _game.PontuarJogador1(); //30 pontos
            _game.PontuarJogador1(); //40 pontos
            _game.PontuarJogador1(); //vitória do jogador 1

            Assert.IsTrue(_game.JogadorVitorioso == _jogador1);
        }

        [TestMethod]
        public void TestVitoriaJogador2()
        {
            _game.PontuarJogador2(); //15 pontos
            _game.PontuarJogador2(); //30 pontos
            _game.PontuarJogador2(); //40 pontos
            _game.PontuarJogador2(); //vitória do jogador 2

            Assert.IsTrue(_game.JogadorVitorioso == _jogador2);
        }

        [TestMethod]
        public void TestEmpate()
        {
            _game.PontuarJogador1(); //15 pontos
            _game.PontuarJogador1(); //30 pontos
            _game.PontuarJogador1(); //40 pontos

            _game.PontuarJogador2(); //15 pontos
            _game.PontuarJogador2(); //30 pontos
            _game.PontuarJogador2(); //40 pontos

            Assert.IsTrue(_game.Empatado.Value);
        }

        [TestMethod]
        public void TestVitoriaPosEmpateJogador1()
        {
            _game.PontuarJogador1(); //15 pontos
            _game.PontuarJogador1(); //30 pontos
            _game.PontuarJogador1(); //40 pontos

            _game.PontuarJogador2(); //15 pontos
            _game.PontuarJogador2(); //30 pontos
            _game.PontuarJogador2(); //40 pontos

            _game.PontuarJogador1(); //empate, vantagem jogador 1
            _game.PontuarJogador1(); //vitória jogador 1

            Assert.IsFalse(_game.Empatado.Value);
        }

        [TestMethod]
        public void TestVitoriaPosEmpateJogador2()
        {
            _game.PontuarJogador1(); //15 pontos
            _game.PontuarJogador1(); //30 pontos
            _game.PontuarJogador1(); //40 pontos

            _game.PontuarJogador2(); //15 pontos
            _game.PontuarJogador2(); //30 pontos
            _game.PontuarJogador2(); //40 pontos, empate, vantagem jogador 2
            _game.PontuarJogador2(); //vitória jogador 2

            Assert.IsFalse(_game.Empatado.Value);
        }
    }
}
