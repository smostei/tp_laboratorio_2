using System;

namespace Entidades
{
    public class Producto
    {
        public enum TipoProducto
        {
            Limpieza,
            Comida,
            Bebida
        }

        private int id;
        private string nombre;
        private TipoProducto tipo;
        private int stockDisponible;
        private double precio;

        public Producto(string nombre, TipoProducto tipo, int stockDisponible, double precio)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.stockDisponible = stockDisponible;
            this.precio = precio;
        }

        public Producto(int id, string nombre, TipoProducto tipo, int stockDisponible, double precio)
           : this(nombre, tipo, stockDisponible, precio)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        
        public TipoProducto Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int StockDisponible
        {
            get
            {
                return stockDisponible;
            }

            set
            {
                stockDisponible = value;
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        } 
    }
}
