using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6_ParallelLops
{
    class ParallelProgram
    {
        public static IEnumerable<int> Range(int start, int end, int step)
        {
            for (int i = start; i < end; i += step)
            {
                yield return i;
            }
        }
        static void Main(string[] args)
        {
            int[] values = new int[100];
            var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            Parallel.Invoke(a, b, c);

            Parallel.For(1, 11, i =>
            {
                Console.WriteLine($"Square of number {i} is {i * i}");
            });

            string[] words = { "oh", "what", "a", "night" };
            Parallel.ForEach(words, word =>
            {
                Console.WriteLine($"{word} has length {word.Length} (Task: {Task.CurrentId})");
            });

            Parallel.ForEach(Range(1, 20, 3), Console.WriteLine);
        }
    }
}
