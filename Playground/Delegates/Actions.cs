using System;
using System.Collections.Generic;

namespace Delegates
{/*
  * Representa um método void que recebe zero ou mais argumentos
  */
    class Actions
    {
        static void Main(string[] _)
        {
            List<Product> products = new List<Product>();
            products.AddRange(new List<Product>()
            {
                new Product("TV",900),
                new Product("Notebook",1200),
                new Product("Tablet",4000),
                new Product("Caneta",10)
            });

            Action<Product> action = UpdatePrice;
            Action<Product> actionLambda = p => { p.Preco += p.Preco * 0.1; };

            products.ForEach(UpdatePrice);
            products.ForEach(action);
            products.ForEach(actionLambda);
            products.ForEach(p => { p.Preco += p.Preco * 0.1; });
        }

        static void UpdatePrice(Product p)
        {
            p.Preco += p.Preco * 0.1;
        }
    }

}
