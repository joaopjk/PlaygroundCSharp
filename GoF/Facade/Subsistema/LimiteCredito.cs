using System;

namespace Facade.Subsistema
{
  public static class LimiteCredito
  {
    public static bool PossuiLimiteCredito(Cliente cliente, double valor)
    {
      Console.WriteLine("Verificando limite de crédito " + cliente.Nome);
      return valor <= 200000;
    }
  }
}
