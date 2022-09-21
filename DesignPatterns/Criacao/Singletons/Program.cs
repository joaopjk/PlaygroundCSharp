using System;
using System.Threading.Tasks;

namespace Singletons
{
  static class Program
  {
    static void Main(string[] _)
    {
      var db = SingletonDatabase.Instance;
      db.GetPopulation("Tokyo");

      //PerThreadSingleton
      var t1 = Task.Factory.StartNew(
        () => Console.WriteLine(PerThreadSingleton.Instance.Id));

      var t2 = Task.Factory.StartNew(
        () => Console.WriteLine(PerThreadSingleton.Instance.Id));

      Task.WaitAll(t1, t2);
    }
  }
}
