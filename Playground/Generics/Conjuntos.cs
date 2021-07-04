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
  */
    class Conjuntos
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            set.Add("João");
            set.Add("Cícero");
            set.Add("Vicente");
            set.Add("Sousa");

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
        }

        static void PrintCollection<T>(IEnumerable<T> collection)//IEnumerable é uma interface implementando em todos as classes das Collections
        {
            foreach (var item in collection)
                Console.Write(item + " ");

            Console.WriteLine();
        }
    }
}
