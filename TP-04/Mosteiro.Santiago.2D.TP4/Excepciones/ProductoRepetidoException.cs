using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ProductoRepetidoException : Exception
    {
        public ProductoRepetidoException() : base() {}
        public ProductoRepetidoException(string mensaje) : base(mensaje) {}
    }
}
