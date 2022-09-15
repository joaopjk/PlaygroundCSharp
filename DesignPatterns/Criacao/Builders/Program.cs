using System;

namespace Builders
{
  static class Program
  {
    static void Main(string[] _)
    {
      #region Example
      var director = new Director();
      var builder = new ConcreteBuilder();
      director.Builder = builder;

      director.BuildMinimalViableProduct();

      director.BuildFullFeatureProduct();

      builder.BuildPartA();
      builder.BUildPartB();
      builder.BuildPartC();
      #endregion
    }
  }
}
