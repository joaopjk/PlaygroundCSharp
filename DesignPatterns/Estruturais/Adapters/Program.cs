using System;
using Autofac;
using Autofac.Features.Metadata;

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

      //Adapter in DI
      var cB = new ContainerBuilder();
      cB.RegisterType<SaveCommand>().As<ICommand>();
      cB.RegisterType<OpenCommand>().As<ICommand>();
      //cB.RegisterType<Button>();
      // cB.RegisterAdapter<ICommand, Button>(_ => new Button(_));
      cB.RegisterAdapter<Meta<ICommand>, Button>(_ =>
       new Button(_.Value, (string)_.Metadata["Name"]));
      cB.RegisterType<Editor>();

      using var c = cB.Build();
      var editor = c.Resolve<Editor>();
      editor.ClickAll();
    }
  }
}
