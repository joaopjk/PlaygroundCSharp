using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace Singletons
{
  interface IDabatase
  {
    int GetPopulation(string name);
  }

  sealed class SingletonDatabase : IDabatase
  {
    private readonly Dictionary<string, int> capitals;

    private SingletonDatabase()
    {
      capitals = File.ReadAllLines("capitals.txt")
      .Batch(2)
      .ToDictionary(
        _ => _.ElementAt(0).Trim(),
        _ => int.Parse(_.ElementAt(1))
      );
    }

    public int GetPopulation(string name)
    {
      return capitals[name];
    }
    public static SingletonDatabase Instance { get; } = new SingletonDatabase();
  }
}