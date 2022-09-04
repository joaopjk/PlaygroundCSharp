using System;
using System.Collections.Generic;

namespace Listas
{/* Dictionary <Tkey,TValue>: É uma coleção de pares chave/valor.
  * - Não admite repetição de objeto chave
  * - Os elementos são indexados pelo objeto chave(não possum posição).
  * - Acesso, inserção e remoção de elementos são rápidos
  * Uso comum: cookies,local storage, qualquer modelo de chave valor.
  * 
  * Dicitionary
  * - Armazenamento em tabela hash
  * - Extremamente rápido: inserção, remoção é busca o(1)
  * - A ordem dos elementos não é garantida
  * 
  * SortedDictionary
  * - Armazenamento em ávore
  * - Rápido: inserção, remoção e busca O(log(n))
  * - Os elmentos são armazenados ordenadamente conforme a implementação do IComparer<T>
  * 
  * Alguns métodos importantes
  * - dictionary[key]: acessa o elemento pela chave informada
  * - Add(key,value)
  * - Clear
  * - Count
  * - ContaisKey(key)
  * - ContaisValue(value)
  * - Remove(key)
  */
  static class Dicionarios
  {
    static void Main(string[] _)
    {
      Dictionary<string, string> cookies = new Dictionary<string, string>
      {
        { "id", "1357889" }
      };
      cookies["user"] = "joao";
      cookies["email"] = "joao@gmail.com";

      foreach (var item in cookies)
      {
        Console.WriteLine(item.Key + " : " + item.Value);
      }
      // _ = cookies.ContainsKey("email");
      // _ = cookies.ContainsValue("joao@gmail.com");
      // _ = cookies.Count;
      cookies.Remove("email");
      cookies.Clear();
    }
  }
}
