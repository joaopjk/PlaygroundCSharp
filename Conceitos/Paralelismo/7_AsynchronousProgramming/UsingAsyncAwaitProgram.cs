using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace _7_AsynchronousProgramming
{
    class UsingAsyncAwaitProgram
    {
        private static int CalculateValue()
        {
            Thread.Sleep(5000);
            return 123;
        }

        public static Task<int> CalculateValueAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return 123;
            });
        }
        static async Task Main(string[] _)
        {
            var calculation = CalculateValueAsync();
            await calculation.ContinueWith(t =>
            {
                var result = t.Result;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            var n = await CalculateValueAsync();
            n = CalculateValueAsync().Result;
            Console.WriteLine(n);

            using (var wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                Console.WriteLine(data);
            }
        }
    }
}
