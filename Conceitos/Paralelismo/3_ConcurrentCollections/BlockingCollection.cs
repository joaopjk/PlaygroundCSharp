using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace _3_ConcurrentCollections
{
  static class BlockingCollection
  {
    private static readonly BlockingCollection<int> Messages = new(new ConcurrentBag<int>(), 10);
    private static readonly CancellationTokenSource Cts = new();
    private static readonly Random Random = new();
    private static void RunProducer()
    {
      while (true)
      {
        Cts.Token.ThrowIfCancellationRequested();
        int i = Random.Next(100);
        Messages.Add(i);
        Console.WriteLine($"+{i}");
        Thread.Sleep(Random.Next(1000));
      }
    }
    private static void RunConsumer()
    {
      foreach (var item in Messages.GetConsumingEnumerable())
      {
        Cts.Token.ThrowIfCancellationRequested();
        Console.WriteLine($"-{item}\t");
        Console.WriteLine(Random.Next(1000));
      }
    }
    public static void Main(string[] _)
    {
      var producer = Task.Factory.StartNew(RunProducer);
      var consumer = Task.Factory.StartNew(RunConsumer);
      try
      {
        Task.WaitAll(new[] { producer, consumer }, Cts.Token);

        Console.ReadKey();
        Cts.Cancel();
      }
      catch (AggregateException ae)
      {
        ae.Handle(e =>
        {
          Console.WriteLine(e);
          return true;
        });
      }
    }
  }
}
