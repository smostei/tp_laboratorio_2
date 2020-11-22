using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class ProductoItem
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
        private float precio;
            
        public ProductoItem(string nombre, TipoProducto tipo, float precio)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.precio = precio;
        }

        public ProductoItem(int id, string nombre, TipoProducto tipo, float precio)
            : this(nombre, tipo, precio)
        {
            this.id = id;
        }

        public ProductoItem() { }

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

        public float Precio
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

                /// <summary>
        /// Un item va a ser igual a una lista de items si el mismo se encuenta en ella
        /// </summary>
        /// <param name="item">producto vendido a comparar</param>
        /// <param name="listaItems">lista contra la que vamos a comparar</param>
        /// <returns>true en caso de que el item se esté en la lista, false en caso contrario</returns>
        public static bool operator ==(ProductoItem item, List<ProductoItem> listaItems)
        {
            bool response = false;

            foreach(ProductoItem i in listaItems)
            {
                if(i.Nombre == item.Nombre)
                {
                    response = true;
                    break;
                }
            }

            return response;
        }

        public static bool operator !=(ProductoItem item, List<ProductoItem> listaItems)
        {
            return !(item == listaItems);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {id}");
            sb.AppendLine($"Nombre: {nombre}");
            sb.AppendLine($"Tipo: {tipo}");
            sb.AppendLine($"Precio: {precio}");
            sb.AppendLine("--------------------------------");

            return sb.ToString();
        }
    }
}
