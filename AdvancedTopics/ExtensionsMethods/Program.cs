using System;
using static System.Console;

namespace ExtensionsMethods
{
  class Foo
  {
    public string Name => "Foo";
  }

  static class ExtensionsMethods
  {
    public static int Measure(this Foo foo)
    {
      return foo.Name.Length;
    }

    public static string ToBinary(this int n)
    {
      return Convert.ToString(n, 2);
    }
  }
  static class Program
  {
    static void Main(string[] _)
    {
      var fooLength = new Foo().Measure();
      WriteLine(fooLength.ToBinary());
    }
  }
}
