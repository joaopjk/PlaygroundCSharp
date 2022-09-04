using System;
using System.Collections.Generic;

namespace Generics
{
  static class Generics
  {
    static void Main(string[] _)
    {
      PrintService printService = new PrintService();

      Console.WriteLine("How many values?");

      int n = Convert.ToInt32(Console.ReadLine());

      for (int i = 0; i < n; i++)
        printService.AddValues(Convert.ToInt32(Console.ReadLine()));

      printService.Print();
      Console.WriteLine("First" + printService.First());

      PrintService<string> printServiceString = new PrintService<string>();
      printServiceString.AddValues("João");
    }

    //Sem generics
    class PrintService
    {
      private readonly int[] _values = new int[10];
      private int _count = 0;

      public void AddValues(int value)
      {
        if (_count == 10)
          throw new InvalidOperationException("PrintService is full");

        _values[_count] = value;
        _count++;
      }

      public int First()
      {
        if (_count == 0)
          throw new InvalidOperationException("PrintService is empty");

        return _values[0];
      }

      public void Print()
      {
        Console.Write("[");

        for (int i = 0; i < _count - 1; i++)
          Console.Write(_values[i] + ", ");

        if (_count > 0)
          Console.Write(_values[_count - 1]);

        Console.Write("]");
      }
    }

    //Com generics
    class PrintService<T>
    {
      private readonly T[] _values = new T[10];
      private int _count = 0;

      public void AddValues(T value)
      {
        if (_count == 10)
          throw new InvalidOperationException("PrintService is full");

        _values[_count] = value;
        _count++;
      }

      public T First()
      {
        if (_count == 0)
          throw new InvalidOperationException("PrintService is empty");

        return _values[0];
      }

      public void Print()
      {
        Console.Write("[");

        for (int i = 0; i < _count - 1; i++)
          Console.Write(_values[i] + ", ");

        if (_count > 0)
          Console.Write(_values[_count - 1]);

        Console.Write("]");
      }
    }

    //Restrições para Generics
    class CalculationService
    {
      public T Max<T>(List<T> list) where T : IComparable // Restringe para o que o T seja uma classe que implementa IComparable.
      {
        if (list.Count == 0)
          throw new ArgumentException("The list can not be empty");

        T max = list[0];
        for (int i = 0; i < list.Count; i++)
        {
          if (list[i].CompareTo(max) > 0)
            max = list[i];
        }

        return max;
      }
    }
  }
}
