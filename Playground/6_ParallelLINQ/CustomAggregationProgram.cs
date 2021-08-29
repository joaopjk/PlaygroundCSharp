using System;
using System.Linq;

namespace _6_ParallelLINQ
{
    class CustomAggregationProgram
    {
        public static void Main(string[] args)
        {
            var sum = Enumerable.Range(1, 1001).Sum();
            Console.WriteLine(sum);
        }
    }
}
