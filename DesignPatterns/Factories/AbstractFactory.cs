using System;
using System.Collections.Generic;
using static System.Console;

namespace Factories
{
  public interface IHotDrink
  {
    void Consume();
  }

  internal class Tea : IHotDrink
  {
    public void Consume()
    {
      WriteLine("This tea is nice but i'd prefere it with milk");
    }
  }

  public interface IHotDrinkFactory
  {
    IHotDrink Prepare(int amout);
  }

  internal class TeaFactory : IHotDrinkFactory
  {
    public IHotDrink Prepare(int amout)
    {
      WriteLine($"Put in a tea bag, boil water, pour {amout} ml, add lemon, enjoy");
      return new Tea();
    }
  }

  public class HotDrinkMachine
  {
    public enum AvailableDrink
    {
      Tea, Coffee
    }

    private readonly Dictionary<AvailableDrink, IHotDrinkFactory> factories = new();

    public HotDrinkMachine()
    {
      foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
      {
        var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("Factories." +
        Enum.GetName(typeof(AvailableDrink), drink)));
        factories.Add(drink, factory);
      }
    }

    public IHotDrink MakeDrink(AvailableDrink drink, int amout)
    {
      return factories[drink].Prepare(amout);
    }
  }

  internal class CoffeeFactory : IHotDrinkFactory
  {
    public IHotDrink Prepare(int amout)
    {
      WriteLine($"Put in a coffee bag, boil water, pour {amout} ml, add mode coffee, enjoy");
      return new Coffee();
    }
  }

  internal class Coffee : IHotDrink
  {
    public void Consume()
    {
      WriteLine("This coffe is the better hot drink in the fucking world");
    }
  }
}