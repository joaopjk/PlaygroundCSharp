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
      #region Example3
      var email = new EmailBuilder()
            .To("email@email.com")
            .From("email@email.com")
            .Subject("Microsoft Builder")
            .Body("Corpo do email")
            .CriarEmail();

      // emailBuilder.To("email@email.com");
      // emailBuilder.From("email@email.com");
      // emailBuilder.Subject("Microsoft Builder");
      // emailBuilder.Body("Corpo do email");
      Console.WriteLine(email.ToString());
      #endregion
    }
  }
}
