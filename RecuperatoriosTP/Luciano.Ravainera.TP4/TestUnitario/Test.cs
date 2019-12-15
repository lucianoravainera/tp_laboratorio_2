using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo correo;
            correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesRepetidos()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Barracas 999", "999-999-9999");
            Paquete paquete2 = new Paquete("Avellaneda 2020", "999-999-9999"); 
            correo += paquete1;
            correo += paquete2;
        }

    }
}
