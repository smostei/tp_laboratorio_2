using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using Excepciones;

namespace Data
{
    public static class DataBaseHelper
    {
        private static SqlCommand command;
        private static SqlConnection sqlConnection;
        private const string connectionStr =
            @"Data Source=.\sqlexpress; Initial Catalog=Ventas; Trusted_Connection=True;";

        static DataBaseHelper()
        {
            sqlConnection = new SqlConnection(connectionStr);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = sqlConnection;
        }

        /// <summary>
        /// Agrega un nuevo elemento a la tabla Productos o ProductosVendidos dependiendo el tipo
        /// throw ProductoRepetidoException
        /// </summary>
        /// <typeparam name="T">parametro generico que puede ser un ProductoItem o Producto</typeparam>
        /// <param name="item">el objeto generico que se va a insertar a la tabla de la DB</param>
        /// <returns>true en caso de poder agregarse a la tabla, false en caso contrario</returns>
        public static bool InsertarItem<T>(T item) where T : ProductoItem
        {
            bool response = true;

            try
            {
                command.Parameters.Clear();
                command.CommandText = GetInsertQuery(item);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                response = false;
                throw new ProductoRepetidoException($"Ya existe un producto con el mismo nombre: {e.Message}");
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return response;
        }

        /// <summary>
        /// Actualiza el stock de un registro en la tabla Productos
        /// </summary>
        /// <typeparam name="nuevoStock">el nuevo stock que quiero para el producto</typeparam>
        /// <param name="idProducto">el criterio por el cual vamos a hacer la query</param>
        /// <returns>true en caso de poder actualizarse el registro, false en caso contrario</returns>
        public static bool ActualizarStockProducto(int nuevoStock, int idProducto)
        {
            bool response = true;

            try
            {
                string query = "UPDATE Productos SET StockDisponible = @stock WHERE Id = @id";

                command.Parameters.Clear();
                command.CommandText = query;

                command.Parameters.AddWithValue("stock", nuevoStock);
                command.Parameters.AddWithValue("id", idProducto);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                response = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return response;
        }

        /// <summary>
        /// Actualiza el stock de un registro en la tabla Productos
        /// </summary>
        /// <typeparam name="nuevoStock">el nuevo stock que quiero para el producto</typeparam>
        /// <param name="nombreProducto">el criterio por el cual vamos a hacer la query (esta vez va a ser el nombre)</param>
        /// <returns>true en caso de poder actualizarse el registro, false en caso contrario</returns>
        public static bool ActualizarStockProducto(int nuevoStock, string nombreProducto)
        {
            bool response = true;

            try
            {
                string query = "UPDATE Productos SET StockDisponible = @stock WHERE Nombre = @nombre";

                command.Parameters.Clear();
                command.CommandText = query;

                command.Parameters.AddWithValue("stock", nuevoStock);
                command.Parameters.AddWithValue("nombre", nombreProducto);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                response = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return response;
        }

        /// <summary>
        /// Consulta que haremos para obtener la lista de items (pueden ser Productos o ProductosVendidos)
        /// </summary>
        /// <typeparam name="T">generico por el cual limitamos la query, puede ser un Producto o un ProductoItem</typeparam>
        /// <param name="stockItems">true -> devuelve los objetos que tienen stock mayor a 0, por defecto esta en false, funciona solo con los Productos</param>
        /// <returns>una lista con los items que necesitemos</returns>
        public static List<T> GetListaItems<T>(bool stockItems = false) where T : ProductoItem
        {
            List<T> listaItems = new List<T>();
            string query = GetSelectQuery(listaItems, stockItems);

            try
            {
                sqlConnection.Open();

                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductoItem item = null;

                    int id = (int)reader["Id"];
                    string nombre = (string)reader["Nombre"];
                    ProductoItem.TipoProducto tipo = (Producto.TipoProducto)Enum.Parse(typeof(Producto.TipoProducto), (string)reader["Tipo"]);
                    float precio = ((float)(double)reader["Precio"]);
                    if (listaItems is List<Producto>)
                    {
                        int stock = (int)reader["StockDisponible"];
                        item = new Producto(id, nombre, tipo, precio, stock);
                    }
                    else
                    {
                        item = new ProductoItem(id, nombre, tipo, precio);
                    }

                    listaItems.Add(item as T);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return listaItems;
        }

        /// <summary>
        /// Elimina un registro de la tabla seleccionada (se está usando para los tests)
        /// </summary>
        /// <param name="nombreProducto">el nombre de producto a eliminar</param>
        /// <param name="tablaProductos">por defecto esta en true, si lo setteamos en false, estaríamos eliminando el item de ProductosVendidos</param>
        /// <returns>true en caso de eliminar el producto, false en caso contrario</returns>
        public static bool EliminarProducto(string nombreProducto, bool tablaProductos = true)
        {
            bool response = true;

            try
            {
                string query =
                    tablaProductos ? "DELETE FROM Productos WHERE Nombre = @nombre" : "DELETE FROM ProductosVendidos WHERE Nombre = @nombre";

                command.Parameters.Clear();
                command.CommandText = query;

                command.Parameters.AddWithValue("nombre", nombreProducto);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                response = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return response;
        }

        /// <summary>
        /// Una query que obtiene un producto por su nombre
        /// </summary>
        /// <param name="nombreProducto">criterio por el cual se realiza la request</param>
        /// <returns>El producto bajo el criterio dado</returns>
        public static Producto GetProductoPorNombre(string nombreProducto)
        {
            Producto productoResponse = null;
            string query = "SELECT * FROM Productos WHERE Nombre = @nombre";

            try
            {
                sqlConnection.Open();

                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string nombre = (string)reader["Nombre"];
                    ProductoItem.TipoProducto tipo = (Producto.TipoProducto)Enum.Parse(typeof(Producto.TipoProducto), (string)reader["Tipo"]);
                    float precio = ((float)(double)reader["Precio"]);
                    int stock = (int)reader["StockDisponible"];

                    productoResponse = new Producto(id, nombre, tipo, precio, stock);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return productoResponse;
        }

        /// <summary>
        /// Este metodo nos sirve para elegir un tipo de query que queramos a la hora de traer una lista de elementos
        /// </summary>
        /// <typeparam name="T">parametro generico que puede ser un ProductoItem o un Producto</typeparam>
        /// <param name="listaItems">La lista que vamos a devolver en la query, con su tipo sabremos que devolver</param>
        /// <param name="stockItems">parametro por defecto en false, si lo ponemos en true nos trae la query con stock mayor a 0</param>
        /// <returns>el string con la query select</returns>
        private static string GetSelectQuery<T>(List<T> listaItems, bool stockItems = false) where T : ProductoItem
        {
            string query;

            if (listaItems.GetType() == typeof(List<ProductoItem>))
            {
                query = "SELECT * FROM ProductosVendidos";
            }
            else
            {
                query = stockItems ? "SELECT * FROM Productos WHERE StockDisponible > 0" : "SELECT * FROM Productos";
            }

            return query;
        }

        /// <summary>
        /// Metodo que nos va a servir para devolvernos la query que queremos hacer segun el item que le pasemos
        /// </summary>
        /// <typeparam name="T">parametro generico que pued ser un ProductoItem o Producto</typeparam>
        /// <param name="item">item por el cual se formará la query</param>
        /// <returns>el string con la query insert</returns>
        private static string GetInsertQuery<T>(T item) where T : ProductoItem
        {
            string query = string.Empty;

            if (item.GetType() == typeof(ProductoItem))
            {
                query = "INSERT INTO ProductosVendidos (Nombre, Tipo, Precio) values " +
                    "(@nombre, @tipo, @precio)";
            }
            else
            {
                query = "INSERT INTO Productos (Nombre, Tipo, Precio, StockDisponible) values " +
                    "(@nombre, @tipo, @precio, @stockDisponible)";
            }

            command.CommandText = query;
            command.Parameters.AddWithValue("nombre", item.Nombre);
            command.Parameters.AddWithValue("tipo", item.Tipo.ToString());
            command.Parameters.Add(new SqlParameter("@precio", item.Precio));

            if (item is Producto)
            {
                command.Parameters.AddWithValue("stockDisponible", (item as Producto).StockDisponible);
            }

            return query;
        }

    }

}