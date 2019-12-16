using System;
using Clases_Instanciables;
using Excepciones;
using Clases_Abstractas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios
{
    [TestClass]
    public class TestAlumnoRepetidoException
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Ricardo", "Alvarez", "34372657", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2, "Jose", "Perez", "34372657", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            uni += a1;
            uni += a2;
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidaException()
        {
            Universidad uni = new Universidad();
            Alumno a3 = new Alumno(2, "Ricardo", "Alvarez", "23000000", Persona.ENacionalidad.Extranjero,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            uni += a3;
        }

        [TestMethod]
        public void ValorNumerico()
        {
            string aux = "37008111";
            Alumno a4 = new Alumno(3, "Alfonso", "Garcia", aux, Persona.ENacionalidad.Argentino,
                    Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Assert.AreEqual(int.Parse(aux), a4.DNI);
        }

        [TestMethod]
        public void ValorNulo()
        {
            Alumno a5 = new Alumno(1, "Ricardo", "Alvarez","34372657", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            Assert.IsNotNull(a5.DNI);
        }
    }
}