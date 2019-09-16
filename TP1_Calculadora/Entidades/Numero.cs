using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   /// <summary>
    /// TP1 Clase Numero.
    /// </summary>
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, le asigna 0 al atributo numero.
        /// </summary>
        public Numero() :this(0)
        {
        }

        /// <summary>
        /// Sobrecarga de constructor que le asigna el numero recibido por parametroi al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(String numero)
        {
            this.SetNumero = numero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Asigna el valor al atributo numero, previa validacion mediante el metodo "ValidarNumero".
        /// </summary>
        public string SetNumero
        { set
            {
                this.numero = Numero.ValidarNumero(value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que valor recibido por parametro sea numerico.(Solo puede ser llamado desde la propiedad "SetNumero")
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>Devuelve el valor numerico en formato double, si no es numerico devuelve 0</returns>
        private static double ValidarNumero(String strNumero)
        {
            double retorno, salida = 0;
            if (double.TryParse(strNumero, out retorno))
            {
                salida = retorno;
            }
            return salida;
        }

        /// <summary>
        /// Convierte un numero binario a decimal en caso de ser posible.
        /// Solo usa el valor absoluto del parametro (Entero positivo).
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Numero convertido a binario, si no se puede devuelve "Valor invalido".</returns>
        public string BinarioDecimal(string binario)
        {
            int auxInt;
            string retorno = "Valor Invalido";
            bool esBinario =false;
            if (int.TryParse(binario, out auxInt))
            {
                for (int i = 2; i <= 9; i++)// valido que el numero sea binario para que no rompa el convert
                {
                    if (esBinario = binario.Contains(i.ToString()))
                    {
                        break;
                    }
                }
                auxInt = Math.Abs(auxInt);
                if (!esBinario)
                {
                    retorno = Convert.ToInt32(auxInt.ToString(), 2).ToString();
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convirte un numero decimal a binario siempre que sea posible
        /// </summary>
        /// <param name="numero">numero a converitir</param>
        /// <returns>numero convertido, de no ser posible retorna "Valor Invalido"</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "valor Invalido";
            int auxInt = (int)numero;
            auxInt = Math.Abs(auxInt);
            retorno = Convert.ToString(auxInt, 2).ToString();

            return retorno;
        }
        /// <summary>
        /// Convirte un numero decimal a binario siempre que sea posible
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>numero convertido, de no ser posible retorna "Valor Invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "valor Invalido";
            double aux;
            if (double.TryParse(numero, out aux))
            {
                retorno = this.DecimalBinario(double.Parse(numero));
            }
            return retorno;
        }
        #endregion

        #region Sobrecargas
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        #endregion


    }
}
