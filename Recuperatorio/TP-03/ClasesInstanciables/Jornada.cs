using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }

            set
            {
                alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }

            set
            {
                clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return instructor;
            }

            set
            {
                instructor = value;
            }
        }

        /// <summary>
        /// metodo que guarda en un archivo de texto la jornada de la clase.
        /// </summary>
        /// <param name="jornada">la jornada a guardar en el archivo</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto archivoTextoHelper = new Texto();

            try
            {
                archivoTextoHelper.Guardar(GetRutaArchivo(), jornada.ToString());
                retorno = true;
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        /// <summary>
        /// metodo que se usara para almacenar la informacion de un archivo de texto en un objeto de tipo string
        /// </summary>
        /// <returns>el objeto con la informacion del archivo en string</returns>
        public static string Leer()
        {
            string datosALeer = string.Empty;
            Texto archivoTextoHelper = new Texto();

            try
            {
                archivoTextoHelper.Leer(GetRutaArchivo(), out datosALeer);
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return datosALeer;
        }

        /// <summary>
        /// Informacion de la jornada (clase, profesor y alumnos)
        /// </summary>
        /// <returns>string con la info completa de una jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine($"CLASE DE {clase} POR {instructor}");
            sb.AppendLine("ALUMNOS:");
            sb.AppendLine(GetListaAlumnos());

            sb.AppendLine("<------------------------------------------------------->");

            return sb.ToString();
        }

        /// <summary>
        /// una jornada sera igual a un alumno cuando él mismo participe de ella.
        /// </summary>
        /// <param name="j">jornada a la cual se quiere saber si hay cierto alumno</param>
        /// <param name="a">alumno probablemente en la jornada</param>
        /// <returns>true si el alumno participa de la jornada, false en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alumno in j.alumnos)
            {
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// un alumno sera agregado a la jornada siempre y cuando no esté en la misma
        /// </summary>
        /// <param name="j">jornada a la cual se quiere agregar el alumno</param>
        /// <param name="a">alumno que se quiere agregar a la jornada</param>
        /// <returns>la jornada en caso de que no se haya repetido el alumno, null en caso contrario</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada retorno = null;

            if(j != a)
            {
                j.alumnos.Add(a);
                retorno = j;
            }

            return retorno;
        }

        /// <summary>
        /// metodo que simplemente devuelve la ruta del archivo del cual queremos almacenar/leer la info de la jornada
        /// </summary>
        /// <returns>path del file</returns>
        private static string GetRutaArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
        }

        /// <summary>
        /// metodo para hacer mas eficaz la conversion de la lista de alumnos a string
        /// </summary>
        /// <returns>string con los alumnos que estan en la jornada</returns>
        private string GetListaAlumnos()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Alumno alumno in alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }
    }
}
