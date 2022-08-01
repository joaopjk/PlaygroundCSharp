using System;

namespace Delegates
{/*
  * Multicast Delegates:
  * - São delegates que guardam a referência para mais de um método
  * - Para adicionar uma referência, pode-se usar o operador +=
  * - A chamada Ivoke executa todos os métodos na ordem que foram adicionados
  * - Seu uso faz sentido para métodos void
  */

    delegate void BinaryNumericOperation(double n1, double n2);
    class MulticastDelegates
    {
        static void Main(string[] args)
        {
            double a = 17, b = 28;

            BinaryNumericOperation op = CalculationService.ShowSum;
            op += CalculationService.ShowMax;

            op.Invoke(a, b);

            Console.ReadKey();
        }
    }

    class CalculationService
    {
        public static void ShowMax(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
        }

        public static void ShowSum(double x, double y)
        {
            double sum = x + y;
            Console.WriteLine(sum);
        }
    }
}
