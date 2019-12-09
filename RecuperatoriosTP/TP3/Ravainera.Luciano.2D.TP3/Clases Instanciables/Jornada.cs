using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using Archivos; //falta proyecto archivos

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores

        /// <summary>
        /// Ctor por defecto, inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor con parametros, llamo al contructor por defecto luego
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">instructor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
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

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        #endregion
        #region Sobrecargas

        /// <summary>
        /// Una jornada es igual a un alumno si este participa en clase
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>true si es ==</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ret = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Una jornada no es igual a un alumno si este no participa en clase
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>true si es !=</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar alumno a la clase si no esyan previamente cargados
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>retorna la jornada modificada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    throw new AlumnoRepetidoException(); //lanza excepcion si esta repetido!
                }
            }

            j.alumnos.Add(a);

            return j;
        }
        #endregion
        /// <summary>
        /// Devuelve la info de la jornada, sobrecarga ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE ");
            sb.Append(this.clase);
            sb.Append(" POR ");
            sb.Append(this.instructor);

            sb.AppendLine("ALUMNOS:");

            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Guardar la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Guardado exitoso</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Leer una jhornada desde archivo de texto
        /// </summary>
        /// <returns>Lectura exitosa</returns>
        public static string Leer()
        {
            string buffer;
            Texto texto = new Texto();

            texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out buffer);
            return buffer;
        }

    }
}
