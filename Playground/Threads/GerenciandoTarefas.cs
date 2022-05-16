using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paralelismos
{
    class GerenciandoTarefas
    {
        static void Main(string[] _)
        {
            Task task1 = new Task(() => ExecutaTrabalho(1));
            task1.Start();
            task1.Wait();

            Task task2 = Task.Run(() => ExecutaTrabalho(2));//Irá colocar a thread dentro deum pool task
            task2.Wait();

            Task<int> task3 = Task.Run(() =>
            {
                return CalcularResultado(1000, 123);
            });
            Console.WriteLine(task3.Result);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void ExecutaTrabalho(int item)
        {
            Console.WriteLine("Trabalho iniciado: {0}", item);
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado: {0}", item);
            Console.WriteLine();
        }

        public static int CalcularResultado(int numero1, int numero2)
        {
            Console.WriteLine("Trabalho iniciado");
            Thread.Sleep(2000);
            Console.WriteLine("Trabalho terminado");
            Console.WriteLine();
            return numero1 + numero2;
        }
    }
}
