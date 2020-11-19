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
                throw new ProductoRepetidoException("Ya existe un producto con el mismo nombre");
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

        public static bool EliminarProducto(string nombreProducto)
        {
            bool response = true;

            try
            {
                string query = "DELETE FROM Productos WHERE Nombre = @nombre";

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