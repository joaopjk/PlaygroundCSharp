using Decorator.Exercicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
  static class Program
  {
    static void Main(string[] _)
    {
      IPizza pizzaMussarela = new Pizza("PizzaMussarela");
      Console.WriteLine(pizzaMussarela.Opcionais());
      Console.WriteLine($"Preço R$ {pizzaMussarela.Preco()}");

      IPizza massaEspecial = new MassaEspecialDecorator(pizzaMussarela);
      IPizza baconDecorator = new BaconDecorator(massaEspecial);
      IPizza bordaDecorator = new BordaRecheadaDecorator(baconDecorator);

      Console.WriteLine(bordaDecorator.Opcionais());
      Console.WriteLine($"Preço R$ {bordaDecorator.Preco()}");

      var bebidas = new List<ICafe>
            {
                new ChocolateDecorator(new Filtrado()),
                new LeiteDecorator(new Filtrado()),
                new ChocolateDecorator(new LeiteDecorator(new CafeExpresso()))
            };

      var filtradoChocolate = bebidas[0];
      Console.WriteLine(filtradoChocolate.Decricao());
      Console.WriteLine($"{filtradoChocolate.Preco()}\n");

      var filtradoLeite = bebidas.Skip(1).First();
      Console.WriteLine(filtradoLeite.Decricao());
      Console.WriteLine($"{filtradoLeite.Preco()}\n");

      var expressoLeiteChocolate = bebidas.Last();
      Console.WriteLine(expressoLeiteChocolate.Decricao());
      Console.WriteLine($"{expressoLeiteChocolate.Preco()}\n");

      Console.ReadKey();
    }
  }
}
