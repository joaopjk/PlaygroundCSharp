using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
    internal class SpinLockingLockRecursion
    {
        private static SpinLock _spinLock = new(true);
        private class BackAccount
        {
            public BackAccount(int balance)
            {
                Balance = balance;
            }
            private int _balance;

            public int Balance
            {
                get => _balance;
                private init => _balance = value;
            }

            public void Deposit(int amount)
            {
                _balance += amount;
            }

            public void Withdraw(int amount)
            {
                _balance -= amount;
            }
        }
        public static void LockRecursion(int x)
        {
            bool lockTaken = false;
            try
            {
                _spinLock.Enter(ref lockTaken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (lockTaken)
                {
                    Console.WriteLine($"Took a lock, x = ${x}");
                    LockRecursion(x - 1);
                    _spinLock.Exit();
                }
                else
                {
                    Console.WriteLine($"Failed to take a lock, x = ${x}");
                }
            }
        }
        private static void Main()
        {
            var tasks = new List<Task>();
            BackAccount ba = new(0);
            SpinLock sl = new();

            for (var i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var j = 0; j < 1000; j++)
                    {
                        var lockTaken = false;
                        try
                        {
                            sl.Enter(ref lockTaken);
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (var j = 0; j < 1000; j++)
                    {
                        var lockTaken = false;
                        try
                        {
                            sl.Enter(ref lockTaken);
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));

                Task.WaitAll(tasks.ToArray());

            }

            Console.WriteLine($"Final Balance {ba.Balance}");

            LockRecursion(5);
        }
    }
}
