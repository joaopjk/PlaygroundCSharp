using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Paralelismos
{
    class ParallelFor_1
    {
        static void Main(string[] _)
        {
            //MUITAS TAREFAS EM PARALELO, COM PARÂMETRO
            //=========================================
            //Tarefa 1: processar 100 itens em série
            //Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa
            //Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção

            for (int i = 0; i < 100; i++)
            {
                Processar(i);
            }

            Parallel.For(0, 99, (i) =>
            {
                Processar(i);
            });

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
