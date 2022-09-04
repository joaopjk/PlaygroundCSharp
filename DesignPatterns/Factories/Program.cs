using System;

namespace Factories
{
  public enum CoordinateSystem
  {
    Cartesian,
    Polar
  }

  public class Point
  {
    private double x, y;

    public Point(
      double a,
      double b,
      CoordinateSystem coordinateSystem = CoordinateSystem.Cartesian)
    {
      switch (coordinateSystem)
      {
        case CoordinateSystem.Cartesian:
          x = a;
          y = b;
          break;
        case CoordinateSystem.Polar:
          x = a * Math.Cos(b);
          y = a * Math.Sin(b);
          break;
        default:
          throw new ArgumentOutOfRangeException(
            nameof(coordinateSystem),
            coordinateSystem,
            "");

      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }
}
