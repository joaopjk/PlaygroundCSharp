using System;
using System.Threading;
using System.Threading.Tasks;

namespace _6_ParallelLops
{
    class ThreadLocalStorageProgram
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            //Parallel.For(0, 1001, x =>
            //{
            //    Interlocked.Add(ref sum, x);
            //});
            Parallel.For(1, 1001,
                () => 0,
                (x, state, tls) =>
                {
                    tls += x;
                    Console.WriteLine($"Task {Task.CurrentId} has sum {tls}");
                    return tls;
                }, partialSum =>
                {
                    Console.WriteLine($"Partial values of task {Task.CurrentId} is {partialSum}");
                    Interlocked.Add(ref sum, partialSum);
                });
            Console.WriteLine($"Sum of 1..1000 = {sum}");
        }
    }
}
