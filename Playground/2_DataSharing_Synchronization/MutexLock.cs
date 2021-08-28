using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
    class MutexLock
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
        public static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var ba = new BackAccount(0);

            Mutex mutex = new Mutex();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if(haveLock) mutex.ReleaseMutex();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if(haveLock) mutex.ReleaseMutex();
                        }
                        
                    }
                }));
            }
        }
    }
}
