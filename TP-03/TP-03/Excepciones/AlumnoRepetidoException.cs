using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base() { }
        public AlumnoRepetidoException(string mensaje) : base(mensaje) { }
    }
}
