using System;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ExcepcionesTest
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void DesencadenarNacionalidadInvalidaException()
        {
            //arrange
            Alumno alumno;
            bool hayExcepcion = false;

            //act
            try
            {
                alumno = new Alumno(1, "Santiago", "Mosteiro", "9999999999",
                     ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(NacionalidadInvalidaException e)
            {
                hayExcepcion = true;
            }

            //assert
            Assert.IsTrue(hayExcepcion);
        }

        public void DesencadenarSinProfesorException()
        {
            //arrange
            bool hayExcepcion = false;
            Universidad uni = new Universidad();

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "41170875",
                ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);

            uni += a1;

            Alumno a2 = new Alumno(1, "Juan", "Lopez", "41170875",
                ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);

            //act
            try
            {
                uni += a2;
            }
            catch (AlumnoRepetidoException e)
            {
                hayExcepcion = true;
            }

            //assert
            Assert.IsTrue(hayExcepcion);
        }
    }
}
