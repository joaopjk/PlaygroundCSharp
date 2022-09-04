using System;
using System.Linq;
using System.Threading.Tasks;

namespace Threads
{
  static class TarefasDeContinuacao
  {
    static void Main(string[] _)
    {
      Task ola = Task.Run(() => Ola());
      ola.ContinueWith((_) =>
          Mundo(),
          TaskContinuationOptions.NotOnFaulted);

      ola.ContinueWith((tarefaAnterior) => Error(tarefaAnterior),
          TaskContinuationOptions.OnlyOnFaulted);

      Task mundo = Task.Run(() => Mundo());
    }

    private static void Ola()
    {
      Console.WriteLine("Olá");
    }

    private static void Mundo()
    {
      Console.WriteLine("Mundo !");
    }

    private static void Error(Task tarefaAnterior)
    {
      var exceptions = tarefaAnterior.Exception.InnerExceptions;
      exceptions.AsEnumerable()?.ToList().ForEach((item) => Console.WriteLine(item));
    }
  }
}
