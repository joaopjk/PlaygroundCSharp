using System;

namespace AbstractFactory
{
  static class Program
  {
    static void Main(string[] _)
    {
      #region Example1
      Console.WriteLine("Client: Testing client code with the first factory type...");
      ClientMethod(new ConcreteFactory1());
      Console.WriteLine();

      Console.WriteLine("Client: Testing the same client code with the second factory type...");
      ClientMethod(new ConcreteFactory2());
      #endregion
      #region  Example2
      IMontadora fabrica = new FabricaHonda();
      ISedan sedan = fabrica.CriarSedan();
      ISuv suv = fabrica.CriarSuv();
      sedan.ExibirDetalhes();
      suv.ExibirDetalhes();

      fabrica = new FabricaHyndai();
      sedan = fabrica.CriarSedan();
      suv = fabrica.CriarSuv();
      sedan.ExibirDetalhes();
      suv.ExibirDetalhes();
      #endregion
      #region Example3
      var boloFactory = MassaAbstractFactory.CriarFabricaMassas(TipoMassa.Bolo);
      var pizzaFactory = MassaAbstractFactory.CriarFabricaMassas(TipoMassa.Pizza);

      var bolo1 = boloFactory.CriarMassa((TipoMassa)TipoBolo.Chocolate);
      var bolo2 = boloFactory.CriarMassa((TipoMassa)TipoBolo.Laranja);

      var pizza1 = pizzaFactory.CriarMassa((TipoMassa)TipoPizza.Mussarela);
      var pizza2 = pizzaFactory.CriarMassa((TipoMassa)TipoPizza.Calabreza);

      Console.WriteLine(bolo1);
      Console.WriteLine(bolo2);
      Console.WriteLine(pizza1);
      Console.WriteLine(pizza2);

      #endregion
      #region  AbstractFactory
      var machine = new HotDrinkMachine();
      //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 100);
      machine.MakeDrink();
      // drink.Consume();
      #endregion
    }

    #region Example1
    public static void ClientMethod(IAbstractFactory factory)
    {
      var productA = factory.CreateProductA();
      var productB = factory.CreateProductB();

      Console.WriteLine(productB.UsefulFunctionB());
      Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
    }
    #endregion
  }
}
