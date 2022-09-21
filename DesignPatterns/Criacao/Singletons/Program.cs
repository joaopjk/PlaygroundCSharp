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

      //Ambient Context
      var house = new Building();

      using (new BuildingContext(3000))
      {
        house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
        house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
      }

      using (new BuildingContext(3500))
      {
        house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
        house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
      }

      using (new BuildingContext(3000))
      {
        house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
      }
    }
  }
}
