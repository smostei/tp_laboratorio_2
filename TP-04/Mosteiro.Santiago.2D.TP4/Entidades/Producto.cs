﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public sealed class Producto : ProductoItem
    {

        private int stockDisponible;
        
        public Producto(int id, string nombre, TipoProducto tipo, float precio, int stockDisponible)
            : base(id, nombre, tipo, precio)
        {
            this.stockDisponible = stockDisponible;
        }

        public Producto(string nombre, TipoProducto tipo, float precio, int stockDisponible)
            : base(nombre, tipo, precio)
        {
            this.stockDisponible = stockDisponible;
        }

        public Producto() { }

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

        public static bool operator ==(Producto producto, List<Producto> listaProductos)
        {
            bool response = false;

            foreach (ProductoItem p in listaProductos)
            {
                if (producto.Nombre == p.Nombre)
                {
                    response = true;
                    break;
                }
            }

            return response;
        }

        public static bool operator !=(Producto producto, List<Producto> listaProductos)
        {
            return !(producto == listaProductos);
        }

        public override string ToString()
        {
            return $"Stock Disponible: {stockDisponible}\n" + base.ToString();
        }

    }
}
