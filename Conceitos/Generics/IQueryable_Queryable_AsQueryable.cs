using System;
using System.Collections.Generic;
using System.Linq;

namespace Listas
{
  static class IQueryable_Queryable_AsQueryable
  {/*
      * Quando usar qual ? 
      *  - IQueryable fornece a funcionalidade para avaliar as consultas em uma fonte de dados específica no qual o tipo de
      *  dado não foi definido e destina-se à implementação de provedores de consulta.
      *  - IQueryable herda da interface IEnumerable de forma que, se ela representar uma consulta, os resultados dessa 
      *  consulta podem ser enumrados. A enumeração faz com que a árvore de expressão de um objeto IQueryable seja executado.
      *  - Queryable fornece um conjunto de métodos estáticos para consultar estruturas de dados que implementam IQueryable<T>
      *  A maioria dos métodos são extensões, podendo ser chamados como um método de instância em qualquer objeto que implementa
      *  IQueryable<T>;
      *  - O método AsQueryable converte um IEnumerable para um IQueryable.
      */
    static void Main(string[] _)
    {
      var numeros = new int[] { 5, 10, 20, 60, 72, 90, 102, 114, 122, 130 };

      double media = numeros.AsQueryable().Average();
      int soma = numeros.AsQueryable().Sum();
      int conta = numeros.AsQueryable().Count();
      int maximo = numeros.AsQueryable().Max();
      int minimo = numeros.AsQueryable().Min();

      Console.WriteLine($"quantidade : {conta}");
      Console.WriteLine($"soma : {soma}");
      Console.WriteLine($"média : {media}");
      Console.WriteLine($"mínimo : {minimo}");
      Console.WriteLine($"máximo : {maximo}");

      // List e array podem ser convertidos para IQueryable.
      List<int> lista = new List<int>
            {
                209,
                105
            };

      int[] array = new int[2];
      array[0] = 230;
      array[1] = 186;

      Teste(lista.AsQueryable());
      Teste(array.AsQueryable());
      Console.ReadLine();

      Console.ReadLine();
    }

    static void Teste(IQueryable<int> items)
    {
      Console.WriteLine($"Média: {items.Average()}");
      Console.WriteLine($"Soma: {items.Sum()}");
    }
  }
}
