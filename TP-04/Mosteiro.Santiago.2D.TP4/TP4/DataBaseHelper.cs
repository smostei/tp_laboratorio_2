using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace TP4
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

        public static bool InsertarProducto(Producto producto)
        {
            bool response = true;

            try
            {
                command.Parameters.Clear();

                string query = "INSERT INTO Productos values " +
                    "(@nombre, @tipo, @precio, @stockDisponible)";

                command.CommandText = query;
                command.Parameters.AddWithValue("nombre", producto.Nombre);
                command.Parameters.AddWithValue("tipo", producto.Tipo.ToString());
                command.Parameters.AddWithValue("precio", producto.Precio);
                command.Parameters.AddWithValue("stockDisponible", producto.StockDisponible);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            } 
            catch(Exception e)
            {
                response = false;
                Console.WriteLine(e.Message);
                //Arrojar una excepcion
            }
            finally
            {
                if(!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return response;
        }

        public static List<Producto> GetListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            string query = "SELECT * FROM Productos";
            
            try
            {
                sqlConnection.Open();

                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {

                    int id = (int)reader["Id"];
                    string nombre = (string)reader["Nombre"];
                    Producto.TipoProducto tipo = (Producto.TipoProducto)Enum.Parse(typeof(Producto.TipoProducto), (string)reader["Tipo"]);
                    int stock = (int)reader["StockDisponible"];
                    double precio = (double)reader["Precio"];

                    Producto p = new Producto(id, nombre, tipo, stock, precio);

                    listaProductos.Add(p);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //throw exception
            }
            finally
            {
                if (!(sqlConnection is null) && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return listaProductos;
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
            catch(Exception e)
            {
                response = false;
                //throw exception
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
    }
}
