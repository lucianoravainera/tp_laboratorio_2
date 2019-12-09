using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        static string mensaje = "Archivos Exception.";

        /// <summary>
        /// Excepción de archivos al leer o guardar
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base(mensaje)
        {

        }
    }
}
