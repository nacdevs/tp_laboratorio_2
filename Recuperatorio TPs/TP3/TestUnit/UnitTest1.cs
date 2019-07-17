using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using Clases_Abstractas;
namespace TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoTest()
        {
            Alumno al = new Alumno(25, "Juan", "Perez", "AAAAA", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoTest()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Perez", "4548485",
           Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            gim += a1;
            Alumno a2 = new Alumno(4, "Juan", "Perez", "4548485",
           Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            gim += a2;
        }

        [TestMethod]
        public void validaNumerico() {
            Alumno a1 = new Alumno(1, "Juan", "Perez", "4548485",
          Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
          Alumno.EEstadoCuenta.Becado);
            if (a1.DNI > 89999999) {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void validaNulo() {      
            Alumno a1 = new Alumno(1, "Juan", "Perez", "4548485",
       Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
       Alumno.EEstadoCuenta.Becado);
           // a1.Nombre = null;
            if (a1.Nombre==null)
            {
                Assert.Fail();
            }
        }

    }
}
