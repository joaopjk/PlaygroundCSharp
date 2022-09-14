using System;
using System.Collections;

namespace AbstractFactory
{
  // Abstract factory com classes abstratas
  enum TipoBolo
  {
    Chocolate = 0, Laranja = 1
  }

  enum TipoMassa
  {
    Pizza = 0, Bolo = 1
  }

  public enum TipoPizza
  {
    Mussarela = 0, Calabreza = 1
  }

  abstract class MassaBase
  {
    public TipoMassa TipoMassa { get; set; }
    public string Nome { get; set; }
    public ArrayList Ingredientes = new();

    protected MassaBase(string nome, TipoMassa tipo)
    {
      Nome = nome;
      TipoMassa = tipo;
    }
  }

  //Abstract class
  abstract class Bolo : MassaBase
  {
    protected Bolo(string nome, TipoMassa tipo) : base(nome, tipo) { }
  }

  abstract class Pizza : MassaBase
  {
    protected Pizza(string nome, TipoMassa tipo) : base(nome, tipo) { }
  }

  //Concrete product
  sealed class BoloCholate : Bolo
  {
    public BoloCholate() : base("Bolo de Chocolate", TipoMassa.Bolo)
    {
      Ingredientes.Add("Com cobertura de nutella");
    }
  }

  sealed class BoloDeLaranja : Bolo
  {
    public BoloDeLaranja() : base("Bolo de Laranja", TipoMassa.Bolo)
    {
      Ingredientes.Add("Com cobertura de laranja cremosa");
    }
  }

  sealed class PizzaMussarela : Pizza
  {
    public PizzaMussarela() : base("Pizza Mussarela", TipoMassa.Pizza)
    {
      Ingredientes.Add("Queijo, Mussarela e molho de tomare");
    }
  }

  sealed class PizzaCalabresa : Pizza
  {
    public PizzaCalabresa() : base("Pizza Calabresa", TipoMassa.Pizza)
    {
      Ingredientes.Add("Queijo, Mussarela e molho de tomare");
    }
  }

  //Factory

  abstract class MassaAbstractFactory
  {
    public abstract MassaBase CriarMassa(TipoMassa tipoMassa);
    public static MassaAbstractFactory CriarFabricaMassas(TipoMassa tipoMassa)
    {
      return tipoMassa switch
      {
        TipoMassa.Pizza => new PizzaFactory(),
        TipoMassa.Bolo => new BoloFactory(),
        _ => throw new Exception(""),
      };
    }
  }

  sealed class PizzaFactory : MassaAbstractFactory
  {
    public override MassaBase CriarMassa(TipoMassa tipoMassa)
    {
      var tipoPizza = (TipoPizza)tipoMassa;

      return tipoPizza switch
      {
        TipoPizza.Mussarela => new PizzaMussarela(),
        TipoPizza.Calabreza => new PizzaCalabresa(),
        _ => throw new Exception(),
      };
    }
  }

  sealed class BoloFactory : MassaAbstractFactory
  {
    public override MassaBase CriarMassa(TipoMassa tipoMassa)
    {
      var tipoBolo = (TipoBolo)tipoMassa;

      return tipoBolo switch
      {
        TipoBolo.Chocolate => new BoloCholate(),
        TipoBolo.Laranja => new BoloDeLaranja(),
        _ => throw new Exception(),
      };
    }
  }
}