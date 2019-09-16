using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            string numero = "4520.47";
            int result;

            //public string BinarioDecimal(string binario)
            //{
            //    int auxInt;
            //    string retorno = "Valor Invalido";
            //    if (int.TryParse(binario, out auxInt))
            //    {
            //        auxInt = Math.Abs(auxInt);
            int BinToDec(string binary)
            {
                int exponente = binary.Length - 1;
                int num_decimal = 0;

                for (int i = 0; i < binary.Length; i++)
                {
                    if (int.Parse(binary.Substring(i, 1)) == 1)
                    {
                        num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                    }
                    exponente--;
                }
                return num_decimal;
            }


            result = BinToDec(numero);
            Console.WriteLine("El numero {0} binario a decimal es:{1}",numero,result);
            Console.ReadLine();
        }
    }
}
