using static System.Console;

namespace Decorators
{
  interface ICreature
  {
    public int Age { get; set; }
  }

  interface IBird2 : ICreature
  {
    void Fly()
    {
      if (Age >= 10)
        WriteLine("I am flying");
    }
  }

  interface ILizard2 : ICreature
  {
    void Crwal()
    {
      if (Age < 10)
        WriteLine("I am crawling");
    }
  }
}