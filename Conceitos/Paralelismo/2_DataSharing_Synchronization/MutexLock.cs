using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
  static class MutexLock
  {
    private class BackAccount
    {
      public BackAccount(int balance)
      {
        Balance = balance;
      }

      public int Balance { get; private set; }

      public void Deposit(int amount)
      {
        Balance += amount;
      }

      public void Withdraw(int amount)
      {
        Balance -= amount;
      }

      public void Tranfer(BackAccount where, int amount)
      {
        Balance -= amount;
        where.Balance += amount;
      }
    }
    public static void Main(string[] _)
    {
      var tasks = new List<Task>();
      var ba = new BackAccount(0);
      var ba2 = new BackAccount(0);

      Mutex mutex = new();
      Mutex mutex2 = new();

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
