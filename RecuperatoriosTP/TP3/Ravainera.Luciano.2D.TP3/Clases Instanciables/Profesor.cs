using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor :Universitario
    {
        private static Random random;
        private Queue<Universidad.EClases> clasesDelDia;

        #region Constructors
        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        public Profesor() : base()
        {
            if (this.clasesDelDia == null)
                this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        /// <summary>
        /// Constructor estático, inicializa el objeto random de tipo estático
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Csontructor con parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClases();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Operador == compara profesor con la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Operador != de profesor y clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        /// <summary>
        /// Generador de clases aleatorio usando random
        /// </summary>
        private void randomClases()
        {
            for (int i = 0; i < 2; i++)
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 5)); // hardwired in this case :p
        }

        /// <summary>
        /// sobreescribo ParticiparEnClase() con "Datos del dia"
        /// </summary>
        /// <returns>devuelve una cadena</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine(); 

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribo el metodo "MostrarDatos"
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" + this.ParticiparEnClase();
        }

        /// <summary>
        /// Hace públicos los datos del profesor metodo ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}
