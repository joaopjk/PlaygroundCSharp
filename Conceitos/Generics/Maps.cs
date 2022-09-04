using System;
using System.Collections.Generic;
using System.Linq;

namespace Listas
{/*
  * Map é o nome de uma função de ordem superior que aplica uma determinada função a cada elemento de um functor, por exemplo
  * lista, contêiner sequencias e etc, retornando uma lista de resultados na mesma ordem.
  */
  static class Maps
  {
    static void Main(string[] _)
    {
      int[] numeros = { 2, 3, 4, 5 };

      var elevarAoQuadrado = ElevarAoQuadrado(numeros?.AsEnumerable().ToList());

      Console.WriteLine(String.Join(" ", elevarAoQuadrado));
    }

    static List<int> ElevarAoQuadrado(List<int> lista)
    {
      var resultado = new List<int>();
      foreach (var x in lista)
        resultado.Add(x * x);
      return resultado.ToList();
    }
  }
}
