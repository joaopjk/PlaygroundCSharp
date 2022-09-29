using System;
using System.Runtime.InteropServices;
using static System.Console;

namespace MemoryManagement
{
  class Point
  {
    public double x, y;

    public Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    public void Reset()
    {
      x = y = 0;
    }
  }
  static class Program
  {
    static double MeasureDistance(in Point p1, in Point p2)
    {
      var dx = p1.x - p2.x;
      var dy = p1.y - p2.y;
      return Math.Sqrt((dx * dx) + (dy * dy));
    }

    static void Main(string[] _)
    {
      var p1 = new Point(1, 1);
      var p2 = new Point(4, 5);

      WriteLine(MeasureDistance(p1, p2));

      unsafe
      {
        byte* ptr = stackalloc byte[100];
        Span<byte> memory = new(ptr, 100);

        IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
        Span<byte> unmanagedMemory = new(unmanagedPtr.ToPointer(), 123);
        Marshal.FreeHGlobal(unmanagedPtr);
      }

      Span<char> arrayMemory = "hello".ToCharArray();
      ReadOnlySpan<char> more = "hi there!".AsSpan();
    }
  }
}
