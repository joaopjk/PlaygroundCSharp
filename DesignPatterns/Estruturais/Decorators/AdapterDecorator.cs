using System.Text;
namespace Decorators
{
  class MyStringBuilder
  {
    private readonly StringBuilder sb = new();

    public static implicit operator MyStringBuilder(string s)
    {
      var msb = new MyStringBuilder();
      msb.sb.Append(s);
      return msb;
    }

    public static MyStringBuilder operator +(MyStringBuilder msb, string s)
    {
      msb.sb.Append(s);
      return msb;
    }
  }
}