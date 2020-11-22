using System;
using System.IO;
using Excepciones;
using Extensiones;

namespace Archivos
{
    public sealed class ArchivoTexto : IArchivo<String>
    {

        /// <summary>
        /// guarda la informacion en un archivo de texto
        /// </summary>
        /// <param name="archivo">path del file</param>
        /// <param name="datos">string que vamos a leer para copiar en el archivo de texto</param>
        /// <returns>true en caso de poder generar el archivo / false en el caso contrario</returns>
        public bool Guardar(string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(RutaArchivo(), true))
                {
                    sw.WriteLine(datos);
                }

                retorno = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e.Message);
            }

            return retorno;
        }

        /// <summary>
        /// lectura de la informacion proveniente de un archivo de texto
        /// </summary>
        /// <param name="archivo">path del file</param>
        /// <param name="datos">direccion de memoria en la cual vamos a almacenar los datos que vienen del archivo</param>
        /// <returns>true en caso de haber recuperado la informacion del archivo / false en caso contrario</returns>
        public bool Leer(out string datos)
        {
            bool retorno = false;
            datos = string.Empty;

            if(File.Exists(RutaArchivo()))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(RutaArchivo()))
                    {
                        while((datos = sr.ReadLine()) != null)
                        {
                            datos += datos + "\n";
                        }
                    }

                    retorno = true;
                }
                catch(Exception e)
                {
                    throw new ArchivosException(e.Message);
                }

            } else
            {
                throw new ArchivosException("El archivo de texto no puede ser leído");
            }

            return retorno;
        }

        public string RutaArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "ListaDeVentas-" + DateTime.Now.FechaActualFormateada() + ".txt";
        }
    }
}
