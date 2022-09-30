using System.Collections.Generic;
using System.Linq;

namespace Commands
{
  static class Program
  {
    static void Main(string[] _)
    {
      //Command
      var ba = new BankAccount();
      var commands = new List<BankAccoumtCommand>
      {
        new BankAccoumtCommand(ba, BankAccoumtCommand.Action.Deposit, 100),
        new BankAccoumtCommand(ba, BankAccoumtCommand.Action.Withdraw, 50)
     };

      foreach (var c in commands)
        c.Call();

      foreach (var c in Enumerable.Reverse(commands))
        c.Undo();
    }
  }
}
