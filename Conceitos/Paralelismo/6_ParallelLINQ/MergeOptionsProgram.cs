using System;
using System.Linq;

namespace _6_ParallelLINQ
{
    class MergeOptionsProgram
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(1, 20).ToArray();

            var results = numbers
                .AsParallel()
                .WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                .Select(x =>
                {
                    var result = Math.Log10(x);
                    Console.WriteLine(result);
                    return result;
                });

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
