using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
    internal class SpinLockingLockRecursion
    {
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
                private set => _balance = value;
            }

            public void Deposit(int amount)
            {
                _balance += amount;
            }

            public void Withdraw(int amout)
            {
                _balance -= amout;
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
                            if(lockTaken) sl.Exit();
                        }
                    }
                }));

                Task.WaitAll(tasks.ToArray());
            }

            Console.WriteLine($"Final Balance {ba.Balance}");
        }
    }
}
