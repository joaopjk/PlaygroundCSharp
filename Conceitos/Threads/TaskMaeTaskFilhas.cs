using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class TaskMaeTaskFilhas
    {
        static void Main(string[] _)
        {
            Task tarefaMae = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Tarefa Mãe iniciou ");

                for (int i = 0; i < 10; i++)
                {
                    int numeroTarefaFilha = i;
                    Task tarefaFilha = Task.Factory.StartNew((id) =>
                    ExecutarFilha(id),
                    numeroTarefaFilha,
                    TaskCreationOptions.AttachedToParent);
                }
            });
            tarefaMae.Wait();
            Console.WriteLine("Tarefa Mãe terminou !");

            Console.ReadLine();
        }

        private static void ExecutarFilha(object i)
        {
            Console.WriteLine("Executando tarefa filha {0}", i);
            Thread.Sleep(1000);
            Console.WriteLine("Finalizado tarefa filha {0}", i);
        }
    }
}
