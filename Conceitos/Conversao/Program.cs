using System;

namespace Conversao
{
    class Program
    {
        static void Main(string[] _)
        {
            //Conversão implicita
            float x = 4.5f;
            double y = x;

            //Conversão explicita
            x = (float)y;

            int a = 5;
            int b = 2;
            double resultado = (double)a / b;

            Console.WriteLine(resultado);
            Console.WriteLine(x);
        }
    }
}
