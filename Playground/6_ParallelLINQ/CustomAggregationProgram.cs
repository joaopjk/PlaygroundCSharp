using System;
using System.Linq;

namespace _6_ParallelLINQ
{
    class CustomAggregationProgram
    {
        public static void Main(string[] args)
        {
            //var sum = Enumerable.Range(1, 1001).Sum();
            //Same value of .Sum
            //var sum = Enumerable.Range(1, 1000)
            //    .Aggregate(0, (i, j) => i + j);
            var sum = ParallelEnumerable.Range(1, 1000)
                .Aggregate(
                    0, //Starting value
                    (partialSum, i) => partialSum += i,
                    (total, subtotal) => total += subtotal,
                    i => 1);

            Console.WriteLine($"sum = {sum}");
        }
    }
}
