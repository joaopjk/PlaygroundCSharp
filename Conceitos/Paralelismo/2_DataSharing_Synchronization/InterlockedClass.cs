using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
  static class InterlockedClass
  {
    private class BackAccount
    {
      private int _balance;
      public int Balance
      {
        get => _balance;
        set => _balance = value;
      }
      public BackAccount(int balance)
      {
        Balance = balance;
      }

      public void Deposit(int amount)
      {
        Interlocked.Add(ref _balance, amount);
      }

      public void Withdraw(int amount)
      {
        Interlocked.Add(ref _balance, -amount);
      }
    }

    private static void Main(string[] _)
    {
      var tasks = new List<Task>();
      BackAccount ba = new(0);

      for (var i = 0; i < 10; i++)
      {
        tasks.Add(Task.Factory.StartNew(() =>
        {
          for (var j = 0; j < 1000; j++)
          {
            ba.Deposit(100);
          }
        }));

        tasks.Add(Task.Factory.StartNew(() =>
        {
          for (var j = 0; j < 1000; j++)
          {
            ba.Withdraw(100);
          }
        }));

        Task.WaitAll(tasks.ToArray());
      }

      Console.WriteLine($"Final Balance {ba.Balance}");
    }
  }
}
