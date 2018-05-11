using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pro_AYD2_1.Tests
{
    [TestClass]
    public class pruebaa
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBComun d = new DBComun();
            int resultado = d.suma(4, 9);
            int esperado = 13;

            Assert.AreEqual(resultado, esperado);
        }
    }
}
