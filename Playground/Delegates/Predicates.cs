using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Delegates
{/*
  * Representa um método que recebe um objeto do tipo T e retorna um valor booleano
  */
    class Predicates
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.AddRange(new List<Product>()
            {
                new Product("TV",900),
                new Product("Notebook",1200),
                new Product("Tablet",4000),
                new Product("Caneta",10)
            });

            products.RemoveAll(p => p.Preco > 100);
            products.RemoveAll(Product.ProductTest);
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
        public static bool ProductTest(Product p)
        {
            return p.Preco >= 100;
        }
    }
}
