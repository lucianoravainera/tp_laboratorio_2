using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado con las nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #region atributos
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad; //es con un enumerado!
        private int dni;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad) : this()
        {
            //this.nombre = nombre;// hay que usar las propiedades ya que en ellas se valida!
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
           : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region propiedades 
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set //usar metodo de validacion "ValidarNombreApellido"
            {
                this.nombre = this.ValidarNombreApellido(value);

            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            { 
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>informacion de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres validos para nombres
        /// </summary>
        /// <param name="dato">cadena a validar</param>
        /// <returns>si la cadena es correcta la devuelve, caso contrario no devuelve null.</returns>
        private string ValidarNombreApellido(string dato)
        {
            string aux = dato;

            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    aux = "";
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Valida que el número de DNI coincida con la nacionalidad de acuerdo a un criterio
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a comparar</param>
        /// <param name="dato">Numero de dni a vvalidar</param>
        /// <returns>Devuelve el número de DNI ya validado, caso contrario tira excepción</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoException();
            }
            else if (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000))
            {
                throw new NacionalidadInvalidaException(); 
            }

            return dato;
        }

        /// <summary>
        /// Valida que el número de DNI dado como cadena no contenga caracteres inválidos
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el número de DNI ya validado, caso contrario tira excepción</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            dato = dato.Replace(" ", "");
            dato = dato.Replace(".", "");
            dato = dato.Replace("-", "");
            dato = dato.Replace(",", "");
            dato = dato.Replace("\t", "");

            if (dato.Length > 9 || !int.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad, dni);
        }
        #endregion
    }
}
