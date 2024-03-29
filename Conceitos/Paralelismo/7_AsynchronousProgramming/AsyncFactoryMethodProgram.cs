﻿using System.Threading.Tasks;

namespace _7_AsynchronousProgramming
{
  static class AsyncFactoryMethodProgram
  {
    public class Foo
    {
      public Foo() { }
      private async Task<Foo> InitAsync()
      {
        await Task.Delay(1000);
        return this;
      }

      public static Task<Foo> CreateAsync()
      {
        var result = new Foo();
        return result.InitAsync();
      }
    }
    //public static async Task Main(string[] args)
    //{
    //    //var foo = new Foo();
    //    //await foo.InitAsync();
    //    Foo x =  Foo.CreateAsync().Result;
    //}
  }
}
