using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.ValueObjects;

namespace Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmpateTest
    {
        public EmpateTest()
        {
        }

        [TestMethod]
        public void TestConstrutores()
        {
            var empate = new Empate();

            Assert.IsFalse(empate.Value);
        }
    }
}