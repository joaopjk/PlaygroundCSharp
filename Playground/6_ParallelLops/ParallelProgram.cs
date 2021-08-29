using System;
using System.Threading.Tasks;

namespace _6_ParallelLops
{
    class ParallelProgram
    {
        static void Main(string[] args)
        {
            int[] values = new int[100];
            var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            Parallel.Invoke(a,b,c);
        }
    }
}
