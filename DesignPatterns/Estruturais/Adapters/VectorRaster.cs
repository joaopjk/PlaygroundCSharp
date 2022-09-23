using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adapters
{
  class Point
  {
    public int x, y;

    public Point(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
  }

  class Line
  {
    public Point Start, End;

    public Line(Point start, Point end)
    {
      Start = start;
      End = end;
    }
  }

  class VectorObject : Collection<Line> { }

  class Rectangle : VectorObject
  {
    public Rectangle(int x, int y, int width, int height)
    {
      Add(new Line(new Point(x, y), new Point(x + width, y)));
      Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
      Add(new Line(new Point(x, y), new Point(x, y + height)));
      Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
    }
  }

  class LineToPointAdapter : Collection<Point>
  {
    private static int count;

    public LineToPointAdapter(Line line)
    {
      ++count;

      int left = Math.Min(line.Start.x, line.End.x);
      int right = Math.Max(line.Start.x, line.End.x);
      int top = Math.Min(line.Start.y, line.End.y);
      int bottom = Math.Max(line.Start.y, line.End.y);
      int dx = right - left;
      int dy = line.End.y - line.Start.y;

      if (dx == 0)
      {
        for (int y = top; y <= bottom; y++)
        {
          Add(new Point(left, y));
        }
      }
      else if (dy == 0)
      {
        for (int x = left; x <= right; ++x)
        {
          Add(new Point(x, top));
        }
      }
    }
  }
}