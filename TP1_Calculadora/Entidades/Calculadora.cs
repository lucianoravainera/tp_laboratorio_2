using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   /// <summary>
    /// TP1 Clase estatica Calculadora.
    /// </summary>
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador String (parámetro) sea +,-,* o /.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>"Devuelve un String con el parámetro validado, sino por defecto devuelve +."</returns>
        private static string ValidarOperador(String operador)
        {
            String retorno = "+";
            if (operador.Equals("-") || operador.Equals("*") || operador.Equals("/"))
            {
                retorno = operador;
            }
            return retorno;
        }

        /// <summary>
        /// Realiza la operacion matematica segun corresponda
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operacion matematica a realizar</param>
        /// <returns>"double Devuelve el resultado de la operación."</returns>
        public static double operar(Numero num1, Numero num2, String operador)
        {
            double retorno = 0; 

            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;
            }

            return retorno;
        }
    }
}
