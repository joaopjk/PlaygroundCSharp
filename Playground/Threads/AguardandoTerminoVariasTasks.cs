using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class AguardandoTerminoVariasTasks
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Números de threads: {0}", Process.GetCurrentProcess().Threads.Count);

            Task[] tarefas = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                int numeroCorredor = i;
                tarefas[i] = Task.Run(() => Correr(numeroCorredor));
            }

            Task.WaitAll(tarefas);

            Console.WriteLine("Números de threads: {0}", Process.GetCurrentProcess().Threads.Count);

            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        public static void Correr(int numeroCorredor)
        {
            Console.WriteLine("Corredor {0} largou", numeroCorredor);
            Thread.Sleep(1000);
            Console.WriteLine("Corredor {0} terminou", numeroCorredor);
        }

        protected void ProcessTasks()
        {
            Task[] tasks = new Task[3]
            {
                 Task.Factory.StartNew(() => Correr(1)),
                 Task.Factory.StartNew(() => Correr(2)),
                 Task.Factory.StartNew(() => Correr(3))
            };
        }
    }
}
