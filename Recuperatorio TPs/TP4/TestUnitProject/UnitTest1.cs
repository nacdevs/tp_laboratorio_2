using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using CorreoUTN;

namespace TestUnitProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstanciaCorreo()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestTracking()
        {
            Correo c = new Correo();
            c += new Paquete("CABA", "92355282");
            c += new Paquete("Baires", "92355282");
        }
    }
}
