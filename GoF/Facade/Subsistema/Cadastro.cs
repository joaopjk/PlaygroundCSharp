using System;

namespace Facade.Subsistema
{
  public static class Cadastro
  {
    public static void CadastrarCliente(Cliente cliente)
    {
      Console.WriteLine($"Cadastro do cliente {cliente.Nome} sem pendências");
    }
  }
}
