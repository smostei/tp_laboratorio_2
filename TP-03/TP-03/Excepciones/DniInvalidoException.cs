using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base() { }
        public DniInvalidoException(string mensaje) : base(mensaje) { }
    }
}
