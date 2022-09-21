using System;

namespace Facade.Subsistema
{
  public static class Serasa
  {
    public static bool EstaNoSerasa(Cliente cliente)
    {
      Console.WriteLine("Verificando SERASA do cliente" + cliente.Nome);
      return false;
    }
  }
}
