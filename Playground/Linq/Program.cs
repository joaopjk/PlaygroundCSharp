using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{/*
  * É um conjunto de tecnologias baseadas na integração de funcionalidade de consulta diretamente lingugaem c#
  * - Operações chamadas diretamente a partir das coleções
  * - Consultas são objetos de primeira classe
  * - Suporte do compilador de IntelliSense da IDE
  * Possui diversar operações de consulta, cujos parâmetros tipicamente são expressões lambda ou expressões de sintaxe
  * similar à SQl
  * 
  * Passos
  * - Criar um data source(coleção, array, recurso de E/S)
  * - Definir a query
  * - Executar a query(foreach ou alguma operação de terminal)
  * 
  * Principais métodos
  * - Filtering: Where,OfType
  * - Sorting: OrderBy,OrdeByDescending,ThenBy,ThenByDescending,Reverse
  * - Set: Distinct,Except,Intersect,Uion
  * - Qunatification: All,Any,Contains
  * - Projection: Select,SelectMany
  * - Partition:Skip,Take
  * - Join:Join,GroupJoin
  * - Grouping:GroupBy
  * - Generational:Empty
  * - Equality:SequenceEquals
  * - Element: ElementeAt,First,FirstOrDefault,Last,LastOrDefault,Single,SingleOrDefault
  * - Concatenation: Concat
  * - Aggregation: Aggregate,Average,Count,LongCount,Max,Min,Sum
  */
    class Program
    {
        static void Main(string[] args)
        {
            // Especificar um data source
            int[] numeros = new int[] { 1, 2, 3, 4, 5 };

            // definir a query
            var result = numeros.Where(n => n % 2 == 0)
                                .Select(n => n * 10);

            //Executar a consulta
            foreach (var item in result)
                Console.WriteLine(item);

            Category c1 = new Category() { Id = 1, Nome = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Nome = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Nome = "Electronics", Tier = 2 };

            List<Product> products = new List<Product>();
            products.AddRange(new List<Product>()
            {
                new Product(1,"TV",900,c3),
                new Product(2,"Notebook",1200,c2),
                new Product(3,"Tablet",4000,c2),
                new Product(4,"Caneta",10,c1)
            });

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Preco < 9000);
        }
    }

    class Category
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Tier { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Category Category { get; set; }

        public Product(int id, string nome, double preco, Category category)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Category = category;
        }
    }
}
