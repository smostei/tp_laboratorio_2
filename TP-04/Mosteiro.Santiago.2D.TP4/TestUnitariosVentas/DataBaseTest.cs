using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using TP4;

namespace TestUnitariosVentas
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void InsertarUnNuevoProductoDisponible()
        {
            //arrange
            string nombreProducto = "Pepsi Light";
            Producto producto = new Producto(nombreProducto, ProductoItem.TipoProducto.Bebida, 50.6f, 2);

            //act
            DataBaseHelper.InsertarItem(producto);

            //assert
            Assert.AreEqual(nombreProducto, DataBaseHelper.GetProductoPorNombre(nombreProducto).Nombre);

            //eliminamos el producto agregado para la prueba
            DataBaseHelper.EliminarProducto(nombreProducto);
        }

        [TestMethod]
        public void TraerTodosLosProductosDisponibles()
        {
            //arrange
            List<Producto> listaProductos = null;

            //act
            listaProductos = DataBaseHelper.GetListaItems<Producto>();

            //assert
            Assert.IsNotNull(listaProductos);
        }

        [TestMethod]
        public void ActualizarStockDeProducto()
        {
            //arrange
            string nombreProducto = "Pepsi Light";
            Producto producto = new Producto(nombreProducto, ProductoItem.TipoProducto.Bebida, 50.6f, 5); //stock 5

            //act
            DataBaseHelper.InsertarItem(producto);
            DataBaseHelper.ActualizarStockProducto(producto.StockDisponible - 1, nombreProducto); //stock 4

            Producto productoActualizado = DataBaseHelper.GetProductoPorNombre(nombreProducto);

            //assert
            Assert.IsTrue(productoActualizado.StockDisponible == producto.StockDisponible - 1);

            //eliminamos el producto agregado para la prueba
            DataBaseHelper.EliminarProducto(nombreProducto);
        }

        [TestMethod]
        public void InsertarNuevaVenta()
        {
            //arrange
            string nombreItem = "Pepsi Light";
            ProductoItem item = new ProductoItem(nombreItem, ProductoItem.TipoProducto.Bebida, 50.6f);

            //act
            DataBaseHelper.InsertarItem(item);

            //assert
            Assert.AreEqual(nombreItem, DataBaseHelper.GetProductoPorNombre(nombreItem).Nombre);

            //eliminamos el producto agregado para la prueba
            DataBaseHelper.EliminarProducto(nombreItem);
        }

    }
}
