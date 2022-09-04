using System;
using System.Collections.Concurrent;

namespace _3_ConcurrentCollections
{
  static class ConcurrentQueueProgram
  {
    private static void Main(string[] _)
    {
      var q = new ConcurrentQueue<int>();
      q.Enqueue(1);
      q.Enqueue(2);

      if (q.TryDequeue(out var result))
      {
        Console.WriteLine($"Removed element {result}");
      }

      if (q.TryPeek(out result))
      {
        Console.WriteLine($"Front element is {result}");
      }

      Console.ReadKey();
    }
  }
}
