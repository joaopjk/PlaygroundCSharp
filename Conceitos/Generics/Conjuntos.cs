using System;
using System.Collections.Generic;

namespace Listas
{/*
  * HashSet<T> e SortedSet<T>: Representa um conjunto de elementos
  * - Não admite repetições 
  * - Elementos não possuem posição
  * - Acesso, inserção e remoção de elementos são rápidos.
  * - Oferece operações eficientes de conjunto: interseção,união,diferença.
  * 
  * HashSet:
  * - Armazenamento em tabela hash
  * - Extremamente rápido: inserção, remoção e busca 0(1)
  * - A ordem dos elementos não é garantida
  * 
  * SortedSet
  * - Armazenamento em ávore
  * - Rápido: inserção, remoção e busca o(log(n))
  * - Os elementos são armazenados ordenadamente conforme implementação IComparer<T>
  * 
  * Principais métodos importantes
  * - Add
  * - Clear
  * - Contais
  * - UnionWith(other): operação de união
  * - IntersectWith(other): operação de interseção
  * - ExceptWith(other): operação de diferença
  * - Remove(T)
  * - RemoveWhere(predicate)
  * 
  * 
  * Como as coleções Hash testam igualdade?
  * - Se GetHashCode e Equals estiverem implementadas: Primeiro GetHashCode, se der igual, usa o Equals para confirma.
  * - Se GetHashCode e Equals não estiverem implementados: Tipos referência -> compara as referências dos objetos
  *                                                        Tipos valor -> compara os valores dos atributos.
  */
  static class Conjuntos
  {
    static void Main(string[] _)
    {
      HashSet<string> set = new HashSet<string>
            {
                "João",
                "Cícero",
                "Vicente",
                "Sousa"
            };

      Console.WriteLine(set.Contains("João"));

      //Conjunto não tem posições
      foreach (var item in set)
      {
        Console.WriteLine(item);
      }

      SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
      SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

      PrintCollection(a);
      PrintCollection(b);

      //Union
      SortedSet<int> c = new SortedSet<int>(a);
      c.UnionWith(b);
      PrintCollection(c);

      //Intersection
      SortedSet<int> d = new SortedSet<int>(a);
      d.IntersectWith(b);
      PrintCollection(d);

      //Difference
      SortedSet<int> e = new SortedSet<int>(a);
      e.ExceptWith(b);
      PrintCollection(e);

      //Comparação entre Hash
      HashSet<Product> products = new HashSet<Product>
            {
                new Product("TV", 900),
                new Product("Notbook", 1900)
            };

      HashSet<Point> points = new HashSet<Point>
            {
                new Point(3, 4),
                new Point(5, 10)
            };

      Product product = new Product("Notbook", 1900);

      Console.WriteLine(products.Contains(product));//False: Sem o GetHashCode e Equal | True: Com GetHashCode e Equal

      Point point = new Point(5, 10);

      Console.WriteLine(points.Contains(point));// True
    }

    static void PrintCollection<T>(IEnumerable<T> collection)//IEnumerable é uma interface implementando em todos as classes das Collections
    {
      foreach (var item in collection)
        Console.Write(item + " ");

      Console.WriteLine();
    }

    struct Point
    {
      public int X { get; set; }
      public int Y { get; set; }

      public Point(int x, int y)
      {
        X = x;
        Y = y;
      }
    }

    class Product
    {
      public string Name { get; set; }
      public double Price { get; set; }

      public Product(string name, double price)
      {
        Name = name;
        Price = price;
      }

      public override bool Equals(object obj)
      {
        return obj is Product product &&
               Name == product.Name &&
               Price == product.Price;
      }

      public override int GetHashCode()
      {
        return HashCode.Combine(Name, Price);
      }
    }
  }
}
