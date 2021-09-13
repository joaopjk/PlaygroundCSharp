using System;

namespace Operadores
{
    public class Aritmeticos
    {
        static void Main(string[] _)
        {
            int n1 = 3 + 4 * 2;
            int n2 = (3 + 4) * 2;
            int n3 = 17 % 2;
            double n4 = (double)10 / 8;
            double n5 = 10.0 / 8.0;

            double a = 1.0, b = -3.0, c = -4.0;
            double delta = Math.Pow(b, 2) - 4.0 * a * c;
            double x1 = -b + Math.Sqrt(delta);

            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
        }
    }
}
