using System.Collections.Generic;
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
                private set => _balance = value;
            }

            public void Deposit(int amount)
            {
                _balance += amount;
            }

            public void Withdraw(int amount)
            {
                _balance -= amount;
            }

            public void Tranfer(BackAccount where, int amount)
            {
                _balance -= amount;
                where.Balance += amount;
            }
        }
        public static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var ba = new BackAccount(0);
            var ba2 = new BackAccount(0);

            Mutex mutex = new Mutex();
            Mutex mutex2 = new Mutex();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Deposit(1);
                        }
                        finally
                        {
                            if (haveLock) mutex.ReleaseMutex();
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
                            ba.Withdraw(1);
                        }
                        finally
                        {
                            if (haveLock) mutex.ReleaseMutex();
                        }
                    }
                }));
            }
        }
    }
}
