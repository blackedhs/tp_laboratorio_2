using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// valida que se instancie la lista de paquetes cuando se crea un correo 
        /// </summary>
        [TestMethod]
        public void TestValidaInstanciaPaquetes()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
        /// <summary>
        /// Valida una excepcion cuando se quiere cargar un paquete con un mismo trackingID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestValidaExceptionTrackingRepetido()
        {
            Correo c = new Correo();
            c += new Paquete("mallorca", "12453652");
            c += new Paquete("lanus", "12453652");
        }

    }
}
