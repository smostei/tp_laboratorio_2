using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class CollectionsTest
    {

        [TestMethod]
        public void ListaAlumnosEnJornadaEsInstanciada()
        {
            //arrange
            Jornada jornada =
                new Jornada(Universidad.EClases.Laboratorio, new Profesor());

            //act
            jornada.Alumnos.Add(new Alumno());

            //assert
            Assert.IsNotNull(jornada.Alumnos);
        }
    }
}
