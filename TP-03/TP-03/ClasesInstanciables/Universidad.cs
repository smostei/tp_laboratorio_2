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
        public enum EClases
        {
            Programacion = 0,
            Laboratorio,
            Legislacion,
            SPD
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

        private static string GetRutaArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
        }
    }
}
