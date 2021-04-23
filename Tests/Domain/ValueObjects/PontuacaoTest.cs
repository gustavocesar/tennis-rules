using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Enums;
using Domain.ValueObjects;

namespace Tests.Domain.ValueObjects
{
    [TestClass]
    public class PontuacaoTest
    {
        private Pontuacao _pontuacao;
        
        public PontuacaoTest()
        {
            _pontuacao = new Pontuacao();
        }

        [TestMethod]
        public void TestConstrutores()
        {
            Assert.IsTrue(_pontuacao.Pontos == (int)PontuacaoEnum.PontuacaoInicial);
        }

        [TestMethod]
        public void TestPontuar1()
        {
            _pontuacao.Pontuar();

            Assert.IsTrue(_pontuacao.Pontos == (int)PontuacaoEnum.PrimeiroPonto);
        }
    }
}