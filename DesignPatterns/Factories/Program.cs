using static System.Console;

namespace Factories
{
  static class Program
  {
    static void Main(string[] _)
    {
      var cartesianPoint = Point.NewCartesianPoint(1, 3);
      var polarPoint = Point.NewPolarPoint(2, 3);

      WriteLine(cartesianPoint.ToString());
      WriteLine(polarPoint.ToString());
    }
  }
}
