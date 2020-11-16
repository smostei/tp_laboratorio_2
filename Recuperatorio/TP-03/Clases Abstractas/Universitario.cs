using ClasesAbstractas;
using System;
using System.Xml.Serialization;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// metodo encapsulado que sera llamado por el ToString para mostrar la informacion del Universitario
        /// </summary>
        /// <returns>Informacion del universitario</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + $"LEGAJO NÚMERO: {legajo}\n";
        }

        /// <summary>
        /// este metodo será implementado por las clases hijas (Alumno y Profesor) para establecer un comportamiento distinto
        /// mediante el cual el universitario participara en la clase
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Un universitario sera igual a otro en caso de que el LEGAJO o el DNI se compartan
        /// </summary>
        /// <param name="u1">primer universitario a comparar</param>
        /// <param name="u2">segundo universitario a comparar</param>
        /// <returns>true si es igual, false en caso contrario</returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool retorno = false;

            if (u1.legajo == u2.legajo || u1.DNI == u2.DNI)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
    }
}
