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
  * - Os elementos são armazenados ordenadamento conforme implementação IComparer<T>
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
        }
    }
}
