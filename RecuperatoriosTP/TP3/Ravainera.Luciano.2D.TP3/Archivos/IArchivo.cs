using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo para guardar
        /// </summary>
        /// <param name="archivo">ruta</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        bool guardar(string archivo, T datos);

        /// <summary>
        /// Metodo para leer archivo
        /// </summary>
        /// <param name="archivo">ruta</param>
        /// <param name="datos">datos leidos</param>
        /// <returns></returns>
        bool leer(string archivo, out T datos);
    }
}
