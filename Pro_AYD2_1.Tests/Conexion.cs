using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pro_AYD2_1.Tests
{
    [TestClass]
    public class Conexion
    {
        [TestMethod]
        public void Testconexcion()
        {

            DBComun d = new DBComun();
            Boolean test = true;
            Boolean esperado = d.conexcion_establecida;


            Assert.AreEqual(test, esperado);
        }
    }
}
