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

        protected override string ParticiparEnClase()
        {
            return $"Clases del dia: {GetClasesDelDia()}";
        }

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
            clasesDelDia.Enqueue((Universidad.EClases) random.Next(0, 3));
            clasesDelDia.Enqueue((Universidad.EClases) random.Next(0, 3));
        }

        private string GetClasesDelDia()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

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
