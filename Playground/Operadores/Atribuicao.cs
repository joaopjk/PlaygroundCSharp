using System;

namespace Operadores
{
    class Atribuicao
    {
        static void Main(string[] _)
        {
            int a = 10;
            a += 15;
            a -= 5;
            a *= 2;
            a /= 2;
            a %= 2;
            a++;
            a--;
            --a;
            ++a;
            Console.WriteLine(a);
        }
    }
}
