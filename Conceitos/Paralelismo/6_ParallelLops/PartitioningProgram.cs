using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace _6_ParallelLops
{
  class PartitioningProgram
  {
    [Benchmark]
    public static void SquareEachValue()
    {
      const int count = 100000;
      var values = Enumerable.Range(0, count);
      var results = new int[count];

      //So any time that you call something like this, do you call delegate a x number of times.
      Parallel.ForEach(values, x => results[x] = (int)Math.Pow(x, 2));
    }
    [Benchmark]
    public static void SquareEachValuesChunked()
    {
      const int count = 100000;
      var values = Enumerable.Range(0, count);
      var results = new int[count];
      var part = Partitioner.Create(0, count, 100000);

      Parallel.ForEach(part, range =>
      {
        for (int i = range.Item1; i < range.Item2; i++)
        {
          results[i] = (int)Math.Pow(i, 2);
        }
      });
    }
    public static void Main(string[] _)
    {
      BenchmarkRunner.Run<PartitioningProgram>();
    }
  }
}
