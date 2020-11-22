using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using Excepciones;
using Data;

namespace TestUnitariosVentas
{
    [TestClass]
    public class ExcepcionesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ProductoRepetidoException))]
        public void EjecutarProductoRepetidoException()
        {
            //arrange
            string nombreProducto = "Pepsi Light-MismoNombreTest";

            if(!(DataBaseHelper.GetProductoPorNombre(nombreProducto) is null)) //Si hay un producto con este nombre, lo borro
            {
                DataBaseHelper.EliminarProducto(nombreProducto);
            }

            Producto p1 = new Producto(nombreProducto, ProductoItem.TipoProducto.Bebida, 50.5f, 5);
            Producto p2 = new Producto(nombreProducto, ProductoItem.TipoProducto.Comida, 78.6f, 2);

            //act
            DataBaseHelper.InsertarItem(p1);
            DataBaseHelper.InsertarItem(p2);
        }

    }
}
