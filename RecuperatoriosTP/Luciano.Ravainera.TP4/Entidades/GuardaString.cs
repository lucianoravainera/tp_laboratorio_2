using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension de la clase String, guarda un .TXT en el escritorio de la maquina.
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">nombre del archivo</param>
        /// <returns>True si guardo, false si hay error</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            try
            {
                using (StreamWriter open = new StreamWriter(ruta, true))
                {
                    open.WriteLine(texto);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar archivo de texto en el escritorio", e);
            }
        }
    }
}
