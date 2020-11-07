using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):
            base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// override de universitario, el profesor participa de la clase dando la misma.
        /// </summary>
        /// <returns>string con la info del profesor dando las clases</returns>
        protected override string ParticiparEnClase()
        {
            return $"CLASES DEL DÍA:\n{GetClasesDelDia()}";
        }

        /// <summary>
        /// informacion del profesor que va a ser leida desde el ToString
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
        
        /// <summary>
        /// Este metodo va a generar dos clases aleatoria entre 0 y 3:
        /// 0 = Programacion
        /// 1 = Laboratorio
        /// 2 = Legislacion
        /// 3 = SPD
        /// </summary>
        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases) random.Next(0, 4));
            clasesDelDia.Enqueue((Universidad.EClases) random.Next(0, 4));
        }

        /// <summary>
        /// metodo que hace mas eficaz la conversion de las clases que da un profesor a una cadena
        /// </summary>
        /// <returns>string de las clases que toma cada profesor</returns>
        private string GetClasesDelDia()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// un profesor va a ser igual a una clase si él mismo comparte la clase que da con la pasada por parametro
        /// </summary>
        /// <param name="p">profesor del cual queremos saber si da cierta clase</param>
        /// <param name="clase">la clase que queremos saber si la da cierto profesor</param>
        /// <returns>true si el profesor da esa clase, false en caso contrario</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach(Universidad.EClases c in p.clasesDelDia)
            {
                if(c == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }
    }
}
