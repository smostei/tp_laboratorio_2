using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException() : base() { }
        public ArchivosException(string mensaje) : base(mensaje) { } 
    }
}
