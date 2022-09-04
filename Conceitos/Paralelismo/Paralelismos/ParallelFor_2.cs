using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paralelismos
{
    class ParallelFor_2
    {
        static void Main(string[] _)
        {
            //Tarefa 1: Processar uma faixa de 100 itens em paralelo
            //Tarefa 2: Completou sem interrupção?
            //Tarefa 3: Interromper quando começar a processar o valor 75
            //Tarefa 4: Quantos itens foram processados (parcialmente)?

            //Tarefa 1:
            ParallelLoopResult parallelLoopResult = Parallel.For(0, 99, (int i, ParallelLoopState state) =>
            {
                //Tarefa 3
                if (i == 75)
                    state.Break();
                Processar(i);
            });

            //Tarefa 2
            Console.WriteLine("Teminou o processo sem interrupção: {0}", parallelLoopResult.IsCompleted);
            //Tarefa 4
            Console.WriteLine("Quantos itens foram processados (parcialmente)? {0}", parallelLoopResult.LowestBreakIteration);
            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}
