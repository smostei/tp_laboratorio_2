using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false))
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

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = string.Empty;

            if(File.Exists(archivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(archivo))
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

    }
}
