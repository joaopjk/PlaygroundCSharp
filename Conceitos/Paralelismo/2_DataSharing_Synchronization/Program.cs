using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _2_DataSharing_Synchronization
{
  internal static class Program
  {
    private class BackAccount
    {
      public int Balance { get; private set; }
      private readonly object _padlock = new();
      public BackAccount(int balance)
      {
        Balance = balance;
      }

      public void Deposit(int amount)
      {
        lock (_padlock)
        {
          Balance += amount;
        }
      }

      public void Withdraw(int amount)
      {
        lock (_padlock)
        {
          Balance -= amount;
        }
      }
    }

    public static void Main()
    {
      //Critical Sections => One method can be access the area at a time
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
