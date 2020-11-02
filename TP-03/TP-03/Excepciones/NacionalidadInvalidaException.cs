using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base() { }
        public NacionalidadInvalidaException(string mensaje) : base(mensaje) { }
    }
}
