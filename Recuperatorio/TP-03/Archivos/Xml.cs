﻿using Excepciones;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// guarda cualquier tipo de objeto en un archivo xml
        /// </summary>
        /// <param name="archivo">path del file</param>
        /// <param name="datos">objeto generico en el cual almacenaremos la info en el xml</param>
        /// <returns>true en caso de poder generar el archivo / false en el caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
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
        /// lectura del archivo xml para almacenar la informacion en un objeto
        /// </summary>
        /// <param name="archivo">path del file</param>
        /// <param name="datos">direccion de memoria del objeto generico, el cual almacenara la info</param>
        /// <returns>true en caso de haber recuperado la informacion del archivo / false en caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer desSerializador = new XmlSerializer(typeof(T));
                        datos = (T) desSerializador.Deserialize(reader);
                    }

                    retorno = true;
                } else
                {
                    throw new ArchivosException("El archivo XML no puede ser leido");
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e.Message);
            }

            return retorno;
        }
    }
}
