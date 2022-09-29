using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public static DateTime DMY(this (int day, int month, int year) when)
    {
      return new(when.year, when.month, when.day);
    }

    public static List<T> Merge<T>(this (IList<T> first, IList<T> second) lists)
    {
      return new List<T>
      {
        (T)lists.first,
        (T)lists.second
      };
    }

    private static readonly Dictionary<WeakReference, object> data = new();

    public static object GetTag(this object o)
    {
      var key = data.Keys.FirstOrDefault(k => k.IsAlive && k.Target == o);
      return key != null ? data[key] : null;
    }

    public static void SetTag(this object o, object tag)
    {
      var key = data.Keys.FirstOrDefault(k => k.IsAlive && k.Target == o);
      if (key != null)
      {
        data[key] = tag;
      }
      else
      {
        data.Add(new WeakReference(o), tag);
      }
    }

    public static StringBuilder Al(this StringBuilder sb, string text)
    {
      return sb.AppendLine(text);
    }

    public static StringBuilder AppendFormatLine(
      this StringBuilder sb,
      string format,
      params object[] args)
    {
      return sb.AppendFormat(format, args).AppendLine();
    }

    public static ulong Xor(params ulong[] values)
    {
      ulong first = values[0];
      foreach (var x in values.Skip(1))
        first ^= x;
      return first;
    }

    public static void AddRange<T>(this IList<T> list, params T[] objects)
    {
      list.AddRange(objects);
    }

    public static string F(this string format, params object[] args)
    {
      return string.Format(format, args);
    }
  }

  class Address
  {
    public string PostCode { get; set; }
  }

  class Person
  {
    public Address Address { get; set; }
  }

  static class Program
  {
    static void Main(string[] _)
    {
      var fooLength = new Foo().Measure();
      WriteLine(fooLength.ToBinary());

      var when = (2, 5, 2001).DMY();
      WriteLine(when);

      // var list1 = new List<int> { 1, 2, 3 };
      // var list2 = new List<int> { 1, 2, 3 };
      // var merge = (list1, list2).Merge();
      // foreach (var n in merge)
      // {
      //   WriteLine(n);
      // }

      const string s = "Meaning of life";
      s.SetTag(42);
      WriteLine(s.GetTag());

      var list = new List<int>();
      list.AddRange(1, 2, 3, 4, 5, 6, 7, 8);

      "My name is {0}".F("Joao Cicero Vicente Sousa");
    }
  }
}
