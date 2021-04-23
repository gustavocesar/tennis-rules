using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;

namespace Tests.Domain.Entities
{
    [TestClass]
    public class JogadorTest
    {
        private Jogador _jogador;

        public JogadorTest()
        {
            _jogador = new Jogador("Jogador Teste");
        }

        [TestMethod]
        public void TestConstrutores()
        {
            //Jogador inválido
            var jogador = new Jogador(null);

            Assert.IsFalse(jogador.IsValid());
        }
    }
}