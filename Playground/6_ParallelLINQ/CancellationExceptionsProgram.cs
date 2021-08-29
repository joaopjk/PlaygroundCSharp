using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _6_ParallelLINQ
{
    class CancellationExceptionsProgram
    {

        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var items = ParallelEnumerable.Range(1, 20);

            var results = items.WithCancellation(cts.Token).Select(i =>
            {
                double result = Math.Log10(i);
                Console.WriteLine($"i = {i}, tid = {Task.CurrentId}");
                return result;
            });

            try
            {
                foreach (var item in results)
                {
                    Console.WriteLine($"result = {item}");
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
        }
    }
}
