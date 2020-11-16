using System;
using System.Text;
using Clases_Abstractas;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno() { }
        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// metodo sobreescrito en Alumno y declarado en Universitario, el Alumno participa en clase tomando la misma
        /// </summary>
        /// <returns>string del alumno tomando una clase</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE: {claseQueToma}";
        }

        /// <summary>
        /// Acumula la data de la jerarquia para que sea visible desde el ToString
        /// </summary>
        /// <returns>cadena con la informacion del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ESTADO DE CUENTA: {estadoCuenta}");
            sb.AppendLine(ParticiparEnClase());

            return base.MostrarDatos() + sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un alumno sera igual a una clase si él mismo la toma
        /// </summary>
        /// <param name="a">alumno a comparar con la clase que toma</param>
        /// <param name="clase">clase que toma</param>
        /// <returns>true en caso de tomar la clase, false en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
    }
}
