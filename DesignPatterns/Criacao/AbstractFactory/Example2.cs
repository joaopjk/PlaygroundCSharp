namespace AbstractFactory
{
  interface ISuv
  {
    string ExibirDetalhes();
  }

  class CretaHyundai : ISuv
  {
    public string ExibirDetalhes()
    {
      return "Hyundai Creta 1.6\nAno 2020";
    }
  }

  class HondaCRV : ISuv
  {
    public string ExibirDetalhes()
    {
      return "Honda CR-V Turbo 190cv\nAno 2020";
    }
  }

  interface ISedan
  {
    string ExibirDetalhes();
  }

  class HB20Hyundai : ISedan
  {
    public string ExibirDetalhes()
    {
      return "HB20 Hyundai 1.6\nAno 2020";
    }
  }

  class HondaCivic : ISedan
  {
    public string ExibirDetalhes()
    {
      return "Honda Civic 1.5 173cv\nAno 2020";
    }
  }

  interface IMontadora
  {
    ISuv CriarSuv();
    ISedan CriarSedan();
  }

  class FabricaHonda : IMontadora
  {
    public ISedan CriarSedan()
    {
      return new HondaCivic();
    }

    public ISuv CriarSuv()
    {
      return new HondaCRV();
    }
  }

  class FabricaHyndai : IMontadora
  {
    public ISedan CriarSedan()
    {
      return new HB20Hyundai();
    }

    public ISuv CriarSuv()
    {
      return new CretaHyundai();
    }
  }

  class ClientMethod
  {
    readonly ISuv suv;
    readonly ISedan sedan;

    public ClientMethod(IMontadora factory)
    {
      suv = factory.CriarSuv();
      sedan = factory.CriarSedan();
    }

    public string GetSuvDetalhes()
    {
      return suv.ExibirDetalhes();
    }

    public string GetSedanDetalhes()
    {
      return sedan.ExibirDetalhes();
    }
  }
}