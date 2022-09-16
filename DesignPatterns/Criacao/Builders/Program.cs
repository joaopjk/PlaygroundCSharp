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
      #region Example2
      var notebookBuilder = new NotebookBuilder();
      var desktopBuilder = new DesktopBuilder();

      Fabricante.Build(notebookBuilder);
      Fabricante.Build(desktopBuilder);
      #endregion

    }
  }
}
