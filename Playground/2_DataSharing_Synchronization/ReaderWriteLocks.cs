using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
    internal class ReaderWriteLocks
    {
        static readonly ReaderWriterLockSlim _padLock = new(LockRecursionPolicy.SupportsRecursion);
        static readonly Random _random = new();

        public static void Main(string[] args)
        {
            //Smart kind of lock
            int x = 0;

            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    _padLock.EnterReadLock();
                    Console.WriteLine($"x= {x}");
                    Thread.Sleep(5000);

                    _padLock.ExitReadLock();
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }

            while (true)
            {
                Console.ReadKey();
                _padLock.EnterWriteLock();
                Console.WriteLine("Write lock required");
                var newValue = _random.Next(10);
                x = newValue;
                Console.WriteLine($"Set x = {x}");
                _padLock.ExitWriteLock();
            }
        }
    }
}
