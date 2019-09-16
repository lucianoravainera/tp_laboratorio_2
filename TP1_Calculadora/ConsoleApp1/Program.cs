using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double prueba = -87.58;
            int resueltado;
            resueltado = (int)Math.Abs(prueba);
            Console.WriteLine("El numero {0} es absoluto:{1}",prueba,resueltado);
            Console.ReadLine();
        }
    }
}
