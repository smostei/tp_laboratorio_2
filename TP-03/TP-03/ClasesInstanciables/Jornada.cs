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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendLine($"CLASE DE {clase} POR {instructor}");
            sb.AppendLine("ALUMNOS:");
            sb.AppendLine(GetListaAlumnos());

            sb.AppendLine("\n<------------------------------------------------------->\n");

            return sb.ToString();
        }

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

        private static string GetRutaArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
        }

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
