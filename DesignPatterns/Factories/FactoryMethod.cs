using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factories
{
  public class Point
  {
    private double x, y;

    private Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    public static Point NewCartesianPoint(double a, double b)
    {
      return new Point(a, b);
    }

    public static Point NewPolarPoint(double rho, double theta)
    {
      return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

    public override string ToString()
    {
      return $"{nameof(x)} : {x} | {nameof(y)} : {y}";
    }
  }
}