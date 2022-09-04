using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Threads
{
  static class Async_Streams
  {/*
      * Agora é possível obter um fluxo de resultados usando o await. Isso é possível através da definição de interfaces
      * iteradoras assyncs no loop foreach e na declaração de yield;
      * - Deve ter uma declaração com o modificador async;
      * - O tipo de retorno deve ser IAsyncEnumerable<T>;
      * - O corpo do método precisa conter pelo menos um return yield para retornar elementos sucessivos no fluxo assíncrono;
      */
    static void Main(string[] _)
    {
      ImprimirSequenciaNumerica().Wait();
    }

    public static async IAsyncEnumerable<int> GerarSequenciaNumerica()
    {
      for (int i = 0; i < 100; i++)
      {
        await Task.Delay(100);
        yield return i;
      }
    }

    public static async Task ImprimirSequenciaNumerica()
    {
      await foreach (var item in GerarSequenciaNumerica())
      {
        Console.WriteLine(item);
      }
    }
    /*
     * Quando se usa a palavra yield em uma instrução, você indica que o método, o operador ou o acessador get em que ela é
     * exibida é um interador.
     */
  }
}
