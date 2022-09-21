using System;

namespace Factories
{
  //Simple Factory
  interface ICelular
  {
    void Especificacao();
  }

  class Nokia : ICelular
  {
    public void Especificacao()
    {
      Console.WriteLine("Nokia");
    }
  }

  class IPhone : ICelular
  {
    public void Especificacao()
    {
      Console.WriteLine("IPhone");
    }
  }

  static class CelularFactory
  {
    public static ICelular CriarCelular(string nome)
    {
      ICelular celular = nome switch
      {
        "N" => new Nokia(),
        "A" => new IPhone(),
        _ => throw new Exception(),
      };
      return celular;
    }
  }
}