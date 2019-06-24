using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethod2()
        {
            Correo c = new Correo();
            c += new Paquete("mallorca", "12453652");
            c += new Paquete("lanus", "12453652");
        }

    }
}
