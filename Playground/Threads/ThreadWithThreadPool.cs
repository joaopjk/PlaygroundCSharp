using System;
using System.Threading;

namespace Threads
{
    class ThreadWithThreadPool
    {
        static void Main(string[] _)
        {
            //1. Task X Thread
            Thread thread1 = new Thread(Executar);
            thread1.Start();
            thread1.Join();

            //2. Thread com expressão lambda
            Thread thread2 = new Thread(() => Executar());
            thread2.Start();
            thread2.Join();

            //3. Passando parâmetro para thread
            ParameterizedThreadStart ps = new ParameterizedThreadStart((p) => ExecutarComParametros(p));
            Thread thread3 = new Thread(ps);
            thread3.Start(123);
            thread3.Join();
            var relogioFuncionando = true;

            //4. Interrompendo um relógio
            Thread thread4 = new Thread(() =>
            {

                while (relogioFuncionando)
                {
                    Console.WriteLine("Tic");
                    Thread.Sleep(1000);
                    Console.WriteLine("Tac");
                    Thread.Sleep(1000);
                }
            });
            thread4.Start();
            Console.WriteLine("Tecle algo para interroper o relógio !");
            Console.ReadKey();
            relogioFuncionando = false;
            thread4.Join();
            //5. Sincronizando uma thread

            //6. Dados da Thread: Nome, cultura, prioridade, contexto, background, pool
            Thread.CurrentThread.Name = "Thread principal";
            ExibirThread(Thread.CurrentThread);

            //7. Usando Thread Pool
            for (int i = 0; i < 50; i++)
            {
                var threadAtual = i;
                ThreadPool.QueueUserWorkItem((state) => ExecutarComParametros(threadAtual));
            }


            Console.ReadLine();
        }

        private static void ExecutarComParametros(object p)
        {
            Console.WriteLine("Inicio da execução {0}", p);
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução {0}", p);
        }

        private static void Executar()
        {
            Console.WriteLine("Inicio da execução");
            Thread.Sleep(1000);
            Console.WriteLine("Fim da execução");
        }

        private static void ExibirThread(Thread t)
        {
            Console.WriteLine("Nome: {0}", t.Name);
            Console.WriteLine("Cultura: {0}", t.CurrentCulture);
            Console.WriteLine("Prioridade: {0}", t.Priority);
            Console.WriteLine("Contexto: {0}", t.ExecutionContext);
            Console.WriteLine("Background: {0}", t.IsBackground);
            Console.WriteLine("Pool: {0}", t.IsThreadPoolThread);
            Console.WriteLine("==================================");
        }
    }
}
