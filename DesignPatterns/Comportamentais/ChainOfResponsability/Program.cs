using System;

namespace ChainOfResponsability
{
  static class Program
  {
    static void Main(string[] _)
    {
      var goblin = new Creature("Goblin", 2, 2);
      Console.WriteLine(goblin);

      var root = new CreatureModifier(goblin);
      root.Add(new NoBonusesModifier(goblin)); // No action happens because the handle function no have action.
      root.Add(new DoubleAttackModifier(goblin));
      root.Add(new IncreasedDefenseModifier(goblin));
      root.Handle();

      Console.WriteLine(goblin.Attack);
      Console.WriteLine(goblin.Defense);
    }
  }
}
