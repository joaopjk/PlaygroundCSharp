using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace _3_ConcurrentCollections
{
  static class ConcurrentDictionaryProgram
  {
    private static readonly ConcurrentDictionary<string, string> capitals = new();

    public static void AddParis()
    {
      bool success = capitals.TryAdd("France", "Paris");
      string who = Task.CurrentId.HasValue ? ("Task" + Task.CurrentId.ToString()) : "Main thread";
      Console.WriteLine($"{who} {(success ? "added" : "did not add")} the element");
    }
    static void Main(string[] _)
    {
      Task.Factory.StartNew(AddParis).Wait();
      AddParis();

      capitals["Russia"] = "Leningrad";
      capitals.AddOrUpdate("Russia", "Moscow", (__, old) => old + "-->Moscow");
      Console.WriteLine($"Capital of Russia is {capitals["Russia"]}");

      capitals["Sweden"] = "Uppsala";
      var capOfSweden = capitals.GetOrAdd("Sweden", "Stockholm");
      Console.WriteLine($"The capital of Sweden is {capOfSweden}");

      const string toRemove = "Russia";
      var didRemove = capitals.TryRemove(toRemove, out var removed);
      if (didRemove)
      {
        Console.WriteLine($"We just removed {removed}");
      }
      else
      {
        Console.WriteLine($"Failed to remove the capital of {toRemove}");
      }

      //Not utilize count if possible
      foreach (var capital in capitals)
      {
        Console.WriteLine($"{capital.Value} is the capital of {capital.Key}");
      }
    }
  }
}
