using System;

namespace Prototypes
{
  //   class Soldado : ICloneable
  //   {
  //     public string Nome { get; set; }
  //     public string Arma { get; set; }
  //     public Soldado() { }
  //     public Soldado(Soldado s)
  //     {
  //       Nome = s.Nome;
  //       Arma = s.Arma;
  //     }

  //     public object Clone()
  //     {
  //       return new Soldado(this);
  //     }
  //   }

  class Acessorio : ICloneable
  {
    public string Nome { get; set; }

    public Acessorio(Acessorio a)
    {
      Nome = a.Nome;
    }

    public object Clone()
    {
      return (Acessorio)MemberwiseClone();
    }
  }
  class Soldado : ICloneable
  {
    public string Nome { get; set; }
    public string Arma { get; set; }
    public Acessorio Acessorio { get; set; }
    public Soldado() { }
    public Soldado(Soldado s)
    {
      Nome = s.Nome;
      Arma = s.Arma;
      Acessorio = s.Acessorio;
    }

    public object Clone()
    {
      Soldado soldado = (Soldado)MemberwiseClone();
      soldado.Acessorio = (Acessorio)Acessorio.Clone();
      return soldado;
    }
  }
}