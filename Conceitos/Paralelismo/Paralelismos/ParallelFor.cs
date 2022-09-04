using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Paralelismos
{
    static class Program
    {
        static void Main(string[] _)
        {
            //TAREFA 1: Cozinhar e refogar EM SÉRIE
            //TAREFA 2: Cozinhar e refogar EM PARALELO
            //TAREFA 3: Medir o tempo dos 2 procedimentos

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            CozinharMacarrao();
            RefogarMolho();
            stopwatch.Stop();
            Console.WriteLine("Sem parallel: {0}", stopwatch.ElapsedMilliseconds / 1000.0);

            stopwatch.Reset();

            stopwatch.Start();
            Parallel.Invoke(() => CozinharMacarrao(),
                            () => RefogarMolho());
            stopwatch.Stop();
            Console.WriteLine("Com parallel: {0}", stopwatch.ElapsedMilliseconds / 1000.0);

            Console.WriteLine(
                "Retire do fogo e ponha o molho sobre o macarrão. " +
                "Bom apetite! " +
                "Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void CozinharMacarrao()
        {
            Console.WriteLine("Cozinhando macarrão...");
            Thread.Sleep(1000);
            Console.WriteLine("Macarrão já está cozido!");
            Console.WriteLine();
        }

        static void RefogarMolho()
        {
            Console.WriteLine("Refogando molho...");
            Thread.Sleep(2000);
            Console.WriteLine("Molho já está refogado!");
            Console.WriteLine();
        }
    }
}
