using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo para guardar un XML implementado de IArchivo
        /// </summary>
        /// <param name="archivo">ruta</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>Devuelve si guardo exitosamente</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T)); // datos.GetType()
                Stream stream = new FileStream(archivo, FileMode.Create);
                xml.Serialize(stream, datos);
                stream.Close();

                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }

        /// <summary>
        /// Metodo para leer un XML implementado de IArchivo
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">dato leido</param>
        /// <returns>Devuelve si leyo exitosamente</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)xml.Deserialize(reader);

                reader.Close();

                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }
    }
}
