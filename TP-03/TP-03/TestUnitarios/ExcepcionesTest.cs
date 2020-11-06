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
        [ExpectedException(typeof(DniInvalidoException))]
        public void DesencadenarDniInvalidoException()
        {
            //arrange
            Alumno alumno;

            //act
            alumno = new Alumno(1, "Santiago", "Mosteiro", "411708755",
                ClasesAbstractas.Persona.ENacionalidad.Argentino, 
                Universidad.EClases.Laboratorio
            );
            
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void DesencadenarNacionalidadInvalidaException()
        {
            //arrange
            Alumno a1;

            //act
            a1 = new Alumno(1, "Juan", "Lopez", "80000000",
                    ClasesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
                    Alumno.EEstadoCuenta.Becado
                 );

        }
    }
}
