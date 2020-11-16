using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        /// <summary>
        /// Los valores enteros son para indicar las clases que puede llegar a dar un profesor con el metodo _randomClases
        /// </summary>
        public enum EClases
        {
            Programacion = 0, //valor 0
            Laboratorio, //valor 1
            Legislacion, //valor 2
            SPD //valor 3 
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
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

        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }

            set
            {
                profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }

            set
            {
                jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }

            set
            {
                jornadas[i] = value;
            }
        }

        /// <summary>
        /// guardara la universidad en un archivo xml
        /// </summary>
        /// <param name="uni">la universidad que será reemplazada por el generico para guardar en el archivo xml</param>
        /// <returns>true si se pudo guardar el archivo, false en caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> serializadorHelper = new Xml<Universidad>();

            try
            {
                retorno = serializadorHelper.Guardar(GetRutaArchivo(), uni);
            } 
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        /// <summary>
        /// metodo que va a leer la informacion de un archivo xml en un objeto de tipo Universidad
        /// </summary>
        /// <returns>La universidad leida del xml</returns>
        public static Universidad Leer()
        {
            Universidad datosALeer = null;
            Xml<Universidad> serializadorHelper = new Xml<Universidad>();

            try
            {
                serializadorHelper.Leer(GetRutaArchivo(), out datosALeer);
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return datosALeer; ;
        }

        /// <summary>
        /// muestra los datos de la universidad, este metodo esta encapsulado porque se va a leer desde el ToString
        /// </summary>
        /// <param name="uni">universidad de la cual vamos a mostrar los datos</param>
        /// <returns>informacion de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada jornada in uni.jornadas)
            {
                sb.AppendLine(jornada.ToString());    
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Una universidad va a ser igual a un alumno, si el mismo se encuentra anotado en ella.
        /// </summary>
        /// <param name="u">universidad de la cual se quiere saber si existe el alumno en ella</param>
        /// <param name="a">alumno que puede o no cursar en la universidad</param>
        /// <returns>true en caso de que el alumno curse en esa universidad, false en caso contrario</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno alumno in u.alumnos)
            {
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Una universidad va a ser igual a un profesor, si el mismo se encuentra dando clases en ella.
        /// </summary>
        /// <param name="u">universidad de la cual se quiere saber si existe el profesor en ella</param>
        /// <param name="p">profesor que puede o no dar clases en la universidad</param>
        /// <returns>true en caso de que el profesor de clases en esa universidad, false en caso contrario</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool retorno = false;

            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// una universidad sera igual a una clase en caso de que haya un profesor dando la misma
        /// </summary>
        /// <param name="u">universidad de la cual se quiere saber si da cierta clase</param>
        /// <param name="clase">clase que puede darse o no en esa universidad</param>
        /// <returns>Retorna el primer profesor encargado de dar esa clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach(Profesor p in u.profesores)
            {
                if(p == clase)
                {
                    profesor = p;
                    break;
                }
            }

            if(profesor == null)
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return profesor;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    profesor = p;
                    break;
                }
            }

            return profesor;
        }

        /// <summary>
        /// Una universidad va agregar cierta clase en caso de que haya un profesor enseñando la misma
        /// throws SinProfesorException
        /// </summary>
        /// <param name="u">universidad en la cual se quiere agregar la clase</param>
        /// <param name="c">clase que puede o no agregarse a la universidad</param>
        /// <returns>retorna la universidad con la clase agregada, o null si no se encontro la clase</returns>
        public static Universidad operator +(Universidad u, EClases c)
        {
            Universidad universidad = null;
            Profesor profesorDisponible = null;

            bool encontroProfesor = false;

            foreach(Profesor p in u.profesores)
            {
                if(p == c)
                {
                    profesorDisponible = p;
                    encontroProfesor = true;
                    break;
                }
            }


            if(encontroProfesor)
            {
                Jornada jornada = new Jornada(c, profesorDisponible);

                foreach (Alumno a in u.alumnos)
                {
                    if (a == c)
                    {
                        jornada += a;
                    }
                }

                u.jornadas.Add(jornada);
                universidad = u;

            } else
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return universidad;
        }

        /// <summary>
        /// una universidad va a agregar a un alumno siempre y cuando el mismo no este ya agregado
        /// throws AlumnoRepetidoException
        /// </summary>
        /// <param name="u">universidad que va a agregar o no al alumno</param>
        /// <param name="a">alumno que puede ser agregado a la universidad</param>
        /// <returns>la universidad con el alumno agregado, excepcion en caso contrario</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool repetido = false;

            foreach(Alumno alumno in u.alumnos)
            {
                if(alumno == a)
                {
                    repetido = true;
                    break;
                }
            }

            if(!repetido)
            {
                u.alumnos.Add(a);
            } else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }

            return u;
        }

        /// <summary>
        /// una universidad va a agregar a un profesor siempre y cuando el mismo no este ya agregado
        /// </summary>
        /// <param name="u">universidad que va a agregar o no al profesor</param>
        /// <param name="p">profesor que puede ser agregado a la universidad</param>
        /// <returns>la universidad con el profesor agregado, null en caso contrario</returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            Universidad universidad = null;
            bool repetido = false;

            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == p)
                {
                    repetido = true;
                    break;
                }
            }

            if (!repetido)
            {
                u.profesores.Add(p);
                universidad = u;
            }

            return universidad;
        }

        /// <summary>
        /// metodo que devuelve la ruta del archivo xml en el cual se almacenara/leera informacion de la universidad
        /// </summary>
        /// <returns>path del file</returns>
        private static string GetRutaArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
        }
    }
}
