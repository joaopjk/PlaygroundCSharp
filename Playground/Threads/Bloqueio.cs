using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Bloqueio
    {
        static long somaGeral;
        static readonly object somaGeralObject = new object();
        static readonly int[] items = Enumerable.Range(0, 100001).ToArray();

        static void AdicionaFaixaDeValores(int inicial, int final)
        {
            long subTotal = 0;
            while (inicial < final)
            {
                subTotal += items[inicial];
                inicial++;
            }
            //lock (somaGeralObject)
            //{
            //    somaGeral += subTotal;
            //}
            Monitor.Enter(somaGeralObject);
            try
            {
                somaGeral += subTotal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(somaGeralObject);
            }
        }

        static void Main(string[] _)
        {
            while (true)
            {
                Executar();
                Thread.Sleep(1000);
            }
        }

        static void Executar()
        {
            somaGeral = 0;
            List<Task> tarefas = new List<Task>();
            int tamanhoFaixa = 1000;
            int inicioFaixa = 0;

            while (inicioFaixa < items.Length)
            {
                int fimFaixa = inicioFaixa + tamanhoFaixa;
                if (fimFaixa > items.Length)
                    fimFaixa = items.Length;

                // cria uma cópia local dos parâmetros
                int i = inicioFaixa;
                int f = fimFaixa;
                tarefas.Add(Task.Run(() => AdicionaFaixaDeValores(i, f)));
                inicioFaixa = fimFaixa;
            }
            Task.WaitAll(tarefas.ToArray());
            Console.WriteLine("A soma geral é: {0}", somaGeral);
        }
    }
}
