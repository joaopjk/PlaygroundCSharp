using System;
using System.Linq;

namespace _6_ParallelLINQ
{
  static class CustomAggregationProgram
  {
    public static void Main(string[] _)
    {
      //var sum = Enumerable.Range(1, 1001).Sum();
      //Same value of .Sum
      //var sum = Enumerable.Range(1, 1000)
      //    .Aggregate(0, (i, j) => i + j);
      int sum = ParallelEnumerable.Range(1, 1000)
                .Aggregate(
                    0, //Starting value
                    (partialSum, i) => partialSum += i,
                    (total, subtotal) => total += subtotal,
                    __ => 1);

      Console.WriteLine($"sum = {sum}");
    }
  }
}
