using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3_ConcurrentCollections
{
    class ConcurrentBagProgram
    {
        public static void Main(string[] args)
        {
            var bag = new ConcurrentBag<int>();
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    bag.Add(j);
                    Console.WriteLine($"{Task.CurrentId} has added {j}");
                    if (bag.TryPeek(out var result))
                        Console.WriteLine($"{Task.CurrentId} has peeked the value {result}");
                }));
            }

            Task.WaitAll(tasks.ToArray());

            if (bag.TryTake(out var last))
                Console.WriteLine($"I got {last}");
        }
    }
}
