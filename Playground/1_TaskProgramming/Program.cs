using System;
using System.Threading;
using System.Threading.Tasks;

namespace _1_TaskProgramming
{
    class Program
    {
        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }
        public static void Write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }
        public static int TextLenght(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}..");
            return o.ToString().Length;
        }
        static void Main(string[] _)
        {
            /*
             * - A unica diferença entre esses dois métodos e que no segundo você precisar startar a task manualmente.
             * - Todas as taks serão executadas simultaneamente.
             */
            Task.Factory.StartNew(() => Write('.'));
            var t = new Task(() => Write('?'));
            Write('-');

            //Outra maneira de criar tasks
            Task t1 = new Task(Write, "Hello");
            t1.Start();

            //Taks method with generics
            string text1 = "testing", text2 = "this";
            var t2 = new Task<int>(TextLenght, text1);
            t2.Start();
            Task<int> t3 = Task.Factory.StartNew(TextLenght, text2);
            Console.WriteLine(t2.Result);
            Console.WriteLine(t3.Result);
            Task.Factory.StartNew(Write, 123);

            //Canceling Tasks
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            //Monitoring if task has been cancel
            token.Register(() =>
            {
                Console.WriteLine("Cancelation has been requested");
            });

            var inifinite = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;//Tambem pode ser cancelado gerando uma exceção do tipo OperationCanceledException();
                              //Pode conferir se a tarefa não foi cancelada com o token.ThrowCancellationRequested()
                    else
                        Console.WriteLine($"{i++}\t");
                }
            }, token);
            inifinite.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle released, cancelation was requested");
            });

            Console.ReadKey();
            cts.Cancel();

            //Cancelation with many tokens
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            //Any of the tokens can cancel the task
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
                planned.Token,
                preventative.Token,
                emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
            }, paranoid.Token);

            Console.ReadKey();

            emergency.Cancel();
            planned.Cancel();
            preventative.Cancel();

            //Waiting for time pass
            var waitinh = new Task(() =>
            {
                /* In this case, the processor will not perform another task, generating wasted memory.
                 * With you need to wait for a little time, this method can be better.
                 * SpinWait.SpinUntil();
                */
                Console.WriteLine("Press any key to disarm the bomb ! You have 5 seconds");
                token.WaitHandle.WaitOne(5000);

            }, token);
            Console.ReadKey();
        }
    }
}
