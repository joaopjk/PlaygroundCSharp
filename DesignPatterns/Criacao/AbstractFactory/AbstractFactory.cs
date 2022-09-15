using System;
using System.Collections.Generic;

namespace AbstractFactory
{
  public interface IHotDrink
  {
    void Consume();
  }

  internal class Tea : IHotDrink
  {
    public void Consume()
    {
      Console.WriteLine("This tea is nice but i'd prefer it with milk.");
    }
  }

  internal class Coffee : IHotDrink
  {
    public void Consume()
    {
      Console.WriteLine("Coffe is the better drink in the fucking world!!");
    }
  }

  public interface IHotDrinkFactory
  {
    IHotDrink Prepare(int amount);
  }

  internal class TeaFactory : IHotDrinkFactory
  {
    public IHotDrink Prepare(int amount)
    {
      Console.WriteLine("Blablalba");
      return new Tea();
    }
  }

  internal class CoffeeFacotory : IHotDrinkFactory
  {
    public IHotDrink Prepare(int amount)
    {
      return new Coffee();
    }
  }

  public class HotDrinkMachine
  {
    // public enum AvailableDrink { Coffee, Tea };
    // readonly Dictionary<AvailableDrink, IHotDrinkFactory> factories = new();

    // public HotDrinkMachine()
    // {
    //   foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
    //   {
    //     var factory = (IHotDrinkFactory)Activator.CreateInstance(
    //         Type.GetType("AbstractFactory."
    //       + Enum.GetName(typeof(AvailableDrink), drink)));
    //     factories.Add(drink, factory);
    //   }
    // }

    // public IHotDrink MakeDrink(AvailableDrink drink, int amount)
    // {
    //   return factories[drink].Prepare(amount);
    // }

    //Abstract Factory and OCP

    private readonly List<Tuple<string, IHotDrinkFactory>> factories = new();
    public HotDrinkMachine()
    {
      foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
      {
        if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
        {
          factories.Add(Tuple.Create(
            t.Name.Replace("Factory", string.Empty),
           (IHotDrinkFactory)Activator.CreateInstance(t)
          ));
        }
      }
    }

    public IHotDrink MakeDrink()
    {
      Console.WriteLine("Available drinks: ");
      for (int i = 0; i < factories.Count; i++)
      {
        var tuple = factories[i];
        Console.WriteLine($"{i}: {tuple.Item1}");
      }

      while (true)
      {
        string s;
        if ((s = Console.ReadLine()) != null
          && int.TryParse(s, out int i)
          && i >= 0
          && i < factories.Count)
        {
          Console.Write("Specify Amount: ");
          s = Console.ReadLine();
          if (s != null
            && int.TryParse(s, out int amount)
            && amount > 0)
          {
            return factories[i].Item2.Prepare(amount);
          }
        }
        Console.WriteLine("Incorrect input, try again!!");
      }
    }
  }
}