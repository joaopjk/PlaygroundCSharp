using System;
using System.Collections.Generic;

namespace Singletons
{
  public sealed class BuildingContext : IDisposable
  {
    public int WallHeight;
    private static readonly Stack<BuildingContext> stack = new();

    static BuildingContext()
    {
      stack.Push(new BuildingContext(0));
    }

    public BuildingContext(int wallHeight)
    {
      WallHeight = wallHeight;
      stack.Push(this);
    }

    public static BuildingContext Current => stack.Peek();

    public void Dispose()
    {
      if (stack.Count > 1)
        stack.Pop();
    }
  }
  struct Point
  {
    private readonly int x, y;

    public Point(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
  }
  class Wall
  {
    public Point Start, End;
    public int Height;

    public Wall(Point start, Point end)
    {
      Start = start;
      End = end;
      Height = BuildingContext.Current.WallHeight;
    }
  }

  class Building
  {
    public List<Wall> Walls = new();
  }
}