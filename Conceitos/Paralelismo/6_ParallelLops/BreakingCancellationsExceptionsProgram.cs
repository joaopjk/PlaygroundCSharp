using System;
using System.Threading;
using System.Threading.Tasks;

namespace _6_ParallelLops
{
  static class BreakingCancellationsExceptionsProgram
  {
    private static void Demo()
    {
      var cts = new CancellationTokenSource();
      ParallelOptions po = new()
      {
        CancellationToken = cts.Token
      };

      var result = Parallel.For(0, 20, po, (int x, ParallelLoopState _) =>
       {
         Console.WriteLine($"{x} [{Task.CurrentId}]");

         if (x == 10)
         {
           //throw new Exception();
           //state.Break();
           //state.Stop();
           cts.Cancel(); // Throw exception
         }
       });

      Console.WriteLine($"Was loop completed? {result.IsCompleted}");
      if (result.LowestBreakIteration.HasValue)
        Console.WriteLine($"Lowest break iterations is {result.LowestBreakIteration}");
    }
    public static void Main(string[] _)
    {
      try
      {
        Demo();
      }
      catch (AggregateException ae)
      {
        ae.Handle(e =>
        {
          Console.WriteLine(e.Message);
          return true;
        });
      }
      catch (OperationCanceledException op)
      {
        Console.WriteLine(op.Message);
      }
    }
  }
}
