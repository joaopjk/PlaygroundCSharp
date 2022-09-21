namespace Singletons
{
  static class Program
  {
    static void Main(string[] _)
    {
      var db = SingletonDatabase.Instance;
      db.GetPopulation("Tokyo");
    }
  }
}
