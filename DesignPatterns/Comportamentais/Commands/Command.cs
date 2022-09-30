using System;

namespace Commands
{
  public class BankAccount
  {
    private int balance;
    private const int overdraftLimit = -5000;

    public void Deposit(int amount)
    {
      balance += amount;
      Console.WriteLine($"Deposited {amount}, balance ins now {balance}");
    }

    public void Withdraw(int amount)
    {
      if (balance - amount >= overdraftLimit)
      {
        balance -= amount;
        Console.WriteLine($"Withdrew {amount}, balance is now {balance}");
      }
    }
  }

  public interface ICommand
  {
    void Call();
    void Undo();
  }

  public class BankAccoumtCommand : ICommand
  {
    private readonly BankAccount account;
    public enum Action
    {
      Deposit, Withdraw
    }
    private Action action;
    private int amount;

    public BankAccoumtCommand(BankAccount account, Action action, int amount)
    {
      this.account = account;
      this.action = action;
      this.amount = amount;
    }

    public void Call()
    {
      switch (action)
      {
        case Action.Deposit:
          account.Deposit(amount);
          break;
        case Action.Withdraw:
          account.Withdraw(amount);
          break;
        default:
          throw new ArgumentException();
      }
    }

    public void Undo()
    {
      switch (action)
      {
        case Action.Deposit:
          account.Withdraw(amount);
          break;
        case Action.Withdraw:
          account.Deposit(amount);
          break;
        default:
          throw new ArgumentException();
      }
    }
  }
}