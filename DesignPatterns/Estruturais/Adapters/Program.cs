using System;

namespace Adapters
{
  static class Program
  {
    static void Main(string[] _)
    {
      //Generic Value Adapter
      // var v = new Vector2i();
      // v[0] = 0;

      // var vv = new Vector2i();
      var v = new Vector2i(1, 2);
      v[0] = 0;

      var vv = new Vector2i(3, 2);
      Console.WriteLine(vv);
    }
  }
}
