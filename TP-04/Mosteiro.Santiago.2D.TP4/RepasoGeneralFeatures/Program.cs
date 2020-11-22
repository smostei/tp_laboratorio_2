using System;
using Data;
using Entidades;
using Excepciones;
using Archivos;
using System.Collections.Generic;
using System.Text;
using Extensiones;

namespace RepasoGeneralFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------FEATURES DISPONIBLES---------------

            //Base de datos:
            //INSERT a productos disponibles (puede arrojar una excepcion si se trata de un producto repetido por nombre):

            Producto p1 = new Producto("ProductoLimpieza", ProductoItem.TipoProducto.Limpieza, 70.5f, 5);
            Producto p2 = new Producto("ProductoLimpieza", ProductoItem.TipoProducto.Limpieza, 100, 2);
            Producto p3 = new Producto("Papas lays", ProductoItem.TipoProducto.Comida, 120, 7);
            Producto p4 = new Producto("Redbull", ProductoItem.TipoProducto.Bebida, 80, 0);

            DataBaseHelper.InsertarItem(p1); //Agrego ProductoLimpieza
            DataBaseHelper.InsertarItem(p3); //Agrego Papas lays
            DataBaseHelper.InsertarItem(p4); //Agrego Redbull

            //Los siguientes productos serán insertados a la tabla Productos para que puedan probarse en el form de ante mano (no son ventas)
            DataBaseHelper.InsertarItem(new Producto("Choripan", ProductoItem.TipoProducto.Comida, 150.5f, 25));
            DataBaseHelper.InsertarItem(new Producto("Jabón en polvo", ProductoItem.TipoProducto.Limpieza, 42.8f, 13));
            DataBaseHelper.InsertarItem(new Producto("Cerveza Quilmes", ProductoItem.TipoProducto.Bebida, 80.6f, 25));

            try
            {
                DataBaseHelper.InsertarItem(p2); //Captura excepcion por repetido
            } 
            catch(ProductoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }

            //INSERT a productos vendidos

            ProductoItem item = new ProductoItem("Fanta", ProductoItem.TipoProducto.Bebida, 95.5f);
            ProductoItem item2 = new ProductoItem("7up", ProductoItem.TipoProducto.Bebida, 95.5f);
            ProductoItem item3 = new ProductoItem("Fanta zero", ProductoItem.TipoProducto.Bebida, 95.5f);

            DataBaseHelper.InsertarItem(item); //Este metodo acepta tanto Producto como ProductoItem (los agrega a su tabla correspondiente)
            DataBaseHelper.InsertarItem(item2); 
            DataBaseHelper.InsertarItem(item3); 

            //UPDATE de stock a algún producto

            DataBaseHelper.ActualizarStockProducto(p1.StockDisponible - 1, "ProductoLimpieza");
            Console.WriteLine($"Nuevo stock: ${p1.StockDisponible}"); //Nuevo stock: 4

            //SELECT de productos
            List<Producto> productosDisponibles = DataBaseHelper.GetListaItems<Producto>();
            List<Producto> productosConStock = DataBaseHelper.GetListaItems<Producto>(true); //Devuelve solo los productos con stock

            foreach(Producto p in productosDisponibles)
            {
                Console.WriteLine(p.ToString());
            }

            foreach (Producto p in productosConStock)
            {
                Console.WriteLine(p.ToString());
            }

            //SELECT de productos vendidos
            List<ProductoItem> productosVendidos = DataBaseHelper.GetListaItems<ProductoItem>();

            foreach (Producto p in productosConStock)
            {
                Console.WriteLine(p.ToString());
            }

            //ARCHIVOS

            ArchivoTexto texto = new ArchivoTexto();
            if (texto.Guardar(GetListaVentas(productosVendidos)))
            {
                Console.WriteLine("Archivo de texto guardado con exito! (ruta del proyecto)");
            }

            ArchivoXml<List<Producto>> xml = new ArchivoXml<List<Producto>>();
            if(xml.Guardar(productosConStock))
            {
                Console.WriteLine("Archivo XML guardado con exito (ruta del proyecto)!");
            }

            //THREADS, DELEGADOS Y EVENTOS
            //Estos están funcionando en los FORM (animaciones y mensajes)

            //METODOS DE EXTENSIÓN
            string fechaActual = DateTime.Now.FechaActualFormateada(); //devuelve la fecha actual -> dd-MM-yyyy
            Console.WriteLine($"Fecha de hoy: {fechaActual}");

            EliminarProductos();
            EliminarProductosVendidos();
        }

        private static string GetListaVentas(List<ProductoItem> listaVentas)
        {
            StringBuilder sb = new StringBuilder();

            foreach (ProductoItem p in listaVentas)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }

        private static void EliminarProductos()
        {
            DataBaseHelper.EliminarProducto("ProductoLimpieza");
            DataBaseHelper.EliminarProducto("Papas lays");
            DataBaseHelper.EliminarProducto("Redbull");
        }

        private static void EliminarProductosVendidos()
        {
            DataBaseHelper.EliminarProducto("Fanta", false);
            DataBaseHelper.EliminarProducto("7up", false);
            DataBaseHelper.EliminarProducto("Fanta zero", false);
        }
    }
}
