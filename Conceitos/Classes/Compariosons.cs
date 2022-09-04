using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Classes
{
  static class Compariosons
  {
    static void Main(string[] _)
    {
      List<Product> products = new List<Product>();
      products.AddRange(new List<Product>()
            {
                new Product("TV",900),
                new Product("Notebook",1200),
                new Product("Tablet",4000)
            });

      products.Sort();

      foreach (var item in products)
        Console.WriteLine(item.Nome);

      products.Sort(CompareProducts);

      Comparison<Product> comp = CompareProducts;
      products.Sort(comp);

      static int comLambda(Product p1, Product p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());
      products.Sort(comLambda);

      products.Sort((p1, p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper()));
    }

    static int CompareProducts(Product p1, Product p2)
    {
      return p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());
    }
  }
  class Product : IComparable<Product>
  {
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Product(string nome, double preco)
    {
      Nome = nome;
      Preco = preco;
    }

    public int CompareTo([AllowNull] Product other)
    {
      return Nome.ToUpper().CompareTo(other.Nome.ToUpper());
    }
  }
}
