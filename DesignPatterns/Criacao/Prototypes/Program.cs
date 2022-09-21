using System;

namespace Prototypes
{
  static class Program
  {
    static void Main(string[] _)
    {
      #region Example
      Soldado soldado = new()
      {
        Nome = "Soldado",
        Arma = "Fuzil"
      };

      var soladoClone1 = (Soldado)soldado.Clone();
      Console.WriteLine(soladoClone1.Arma);
      #endregion
    }
  }
}
