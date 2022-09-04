using System;
using System.Collections.Concurrent;
using System.Linq;

namespace _3_ConcurrentCollections
{
  static class ConcurrentStackProgram
  {
    public static void Main(string[] _)
    {
      var stack = new ConcurrentStack<int>();

      stack.Push(1);
      stack.Push(2);
      stack.Push(3);
      stack.Push(4);
      stack.Push(5);

      if (stack.TryPeek(out var result))
        Console.WriteLine($"{result} is on top");

      if (stack.TryPop(out var result2))
        Console.WriteLine($"Popped {result2}");

      var items = new int[5];
      if (stack.TryPopRange(items, 0, 5) > 0)//Return many of elements you can pop
      {
        var text = string.Join(",", items.Select(i => i.ToString()));
        Console.WriteLine($"Popped these items : {text}");
      }
    }
  }
}
