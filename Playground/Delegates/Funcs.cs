using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{/*
  * Representa um método que recebe zeo ou mais argumentos, retorna um valor 
  */
    class Funcs
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

            Func<Product, string> func = NameUpper;
            func = p => p.Nome.ToUpper();

            List<string> result = products.Select(NameUpper).ToList();
            result = products.Select(p => p.Nome.ToUpper()).ToList();
            result = products.Select(func).ToList();
        }

        static string NameUpper(Product p)
        {
            return p.Nome.ToUpper();
        }
    }
}
