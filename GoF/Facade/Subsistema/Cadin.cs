using System;

namespace Facade.Subsistema
{
  internal static class Cadin
  {
    public static bool EstaNoCadin(Cliente cliente)
    {
      Console.WriteLine("Verificando CADIN do cliente" + cliente.Nome);
      return false;
    }
  }
}
