using System;
using System.Text;
using System.Xml.Serialization;
using Clases_Abstractas;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public Persona() {  }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = ValidarDni(nacionalidad, dni);
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = ValidarDni(nacionalidad, dni);
            this.nacionalidad = nacionalidad;
        }

        public string Nombre
        {
            get
            {
                if(String.IsNullOrWhiteSpace(nombre))
                {
                    return "Nombre no encontrado";
                } else
                {
                    return nombre;
                }
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                if (String.IsNullOrWhiteSpace(apellido))
                {
                    return "Apellido no encontrado";
                }
                else
                {
                    return apellido;
                }
            }

            set
            {
                apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                if(ValidarDni(nacionalidad, dni) != 1)
                {
                    return dni;
                }

                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");
            }
            
            set
            {
                if(ValidarDni(nacionalidad, value) != 1)
                {
                    dni = value;
                }

                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }

            set
            {
                nacionalidad = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMRE COMPLETO: {apellido}, {nombre}");
            sb.AppendLine($"NACIONALIDAD: {nacionalidad}");

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(dato.ToString().Length > 8)
            {
                throw new DniInvalidoException("La longitud del DNI no coincide");
            }

            bool dniValido;

            if(nacionalidad == ENacionalidad.Argentino)
            {
                dniValido = dato >= 1 && dato <= 89999999;
            } else
            {
                dniValido = dato >= 90000000 && dato <= 99999999;
            }

            int retorno = dniValido ? dato : 1;

            return retorno;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int.TryParse(dato, out int auxDni);

            if(auxDni == 0)
            {
                throw new DniInvalidoException("El DNI no cumple con caracteres válidos");
            }

            return this.ValidarDni(nacionalidad, auxDni);
        }

        private string ValidarNombreApellido(string dato)
        {
            if(String.IsNullOrWhiteSpace(dato))
            {
                return "nombre y apellido no especificados";
            }

            return dato;
        }
    }
}
