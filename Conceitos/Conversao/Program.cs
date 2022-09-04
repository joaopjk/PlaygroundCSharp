using System;

namespace Conversao
{
  static class Program
  {
    static void Main(string[] _)
    {
      //Conversão implicita
      float x = 4.5f;
      double y = x;

      //Conversão explicita
      x = (float)y;

      const int a = 5;
      const int b = 2;
      const double resultado = (double)a / b;

      Console.WriteLine(resultado);
      Console.WriteLine(x);
    }
  }
}
