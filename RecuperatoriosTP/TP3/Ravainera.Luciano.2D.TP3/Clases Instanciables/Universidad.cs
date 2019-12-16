using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion , Laboratorio, SPD, Legislacion
        }

        private List<Alumno> alumnos;    
        private List<Jornada> jornada;     
        private List<Profesor> profesores;
        #region Constructor
        /// <summary>
        /// Constructor por default, inicializo las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion
        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion
        #region Sobrecargas

        /// <summary>
        /// Una universidad es igual a un alumno si este esta inscripta en el
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Opuesto al universidad == alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Opuesto a Universidad == Profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agregar una Clase a la Universidad, creando una nuva Jornada
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelvo la universidad modificada</returns>
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            Profesor profesor = (u == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno item in u.Alumnos)
            {
                if (item == clase)
                {
                    jornada = jornada + item;
                }
            }

            u.Jornadas.Add(jornada);

            return u;
        }

        /// <summary>
        /// Agregar a la Universidad un Alumno si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelvo la universidad modificada</returns>
        public static Universidad operator +(Universidad g, Alumno a) 
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.Alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Operador
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelvo la universidad modificada</returns>
        public static Universidad operator +(Universidad g, Profesor i)  
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            else
            {
                throw new SinProfesorException();
            }

            return g;
        }

        /// <summary>
        /// Busco el primer Profesor que pueda dar la Clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que pueda dar la clase, sino lanzo Excepcion</returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Opuesto Universidad == Clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            Profesor p = (g == clase);
            if (!(p is null))
            {
                return p;
            }

            throw new SinProfesorException();
        }

        #endregion
        #region Metodos
        /// <summary>
        /// Muestra los datos de la universidad, los hago publicos en el ToString
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada jor in uni.jornada)
            {
                sb.Append(jor.ToString());
                sb.AppendLine("<------------------------------------------------>\n");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Hago publicos los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Metodo que guarda la universidad en un archivo XML
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
        }
       /// <summary>
       /// Metodo para leer un archivo XML con la universidad
       /// </summary>
       /// <returns>la universidad leida</returns>
        public static Universidad Leer()
        {
            Universidad uniAux = null;

            Xml<Universidad> xmluni = new Xml<Universidad>();
            xmluni.leer("Universidad.xml", out uniAux);

            return uniAux;
        }
        #endregion
    }
}
