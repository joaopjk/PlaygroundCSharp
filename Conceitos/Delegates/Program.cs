using System;

namespace Delegates
{
  static class Program
  {/*
      * Delegae: é uma referência (type safety) para um ou mais métodos.
      * Uso comuns: 
      * - Comunicação entre objetos de forma flexível e extensível(eventos/callback)
      * - Parametrização de operações por métodos(programação funcional)
      * Delegates pré-definidos
      * - Action
      * - Func
      * - Predicate
      */
    delegate double BinaryNumericOperation(double n1, double n2);
    static void Main(string[] _)
    {
      const double a = 10, b = 12;

      BinaryNumericOperation sum = CalculationService.Sum;
      BinaryNumericOperation max = CalculationService.Max;

      double result = sum(a, b);
      double maior = max.Invoke(a, b);

      Console.WriteLine(result);
      Console.WriteLine(maior);
    }

    static class CalculationService
    {
      public static double Max(double x, double y)
      {
        return (x > y) ? x : y;
      }

      public static double Sum(double x, double y)
      {
        return x + y;
      }

      public static double Square(double x)
      {
        return x * x;
      }
    }
  }
}
