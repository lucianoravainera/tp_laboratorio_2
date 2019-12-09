using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario() :base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
             :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// ´Devuelve un string con los datos
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return sb.ToString();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool aux = false;

            if ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
                aux = true;

            return aux;
        }

        public override bool Equals(object obj)
        {
            bool aux = false;

            if (obj.GetType() == this.GetType())
            {
                aux = (this == ((Universitario)obj));
            }

            return aux;
        }
    }
}
