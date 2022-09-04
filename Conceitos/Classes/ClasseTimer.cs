using System;

namespace Classes
{/*
  * System.Windows.Forms.Timer: Implementa um temporizador que aciona um evento em intervalos definidos pelo usuário.
  * System.Timers: Gera um evento após um intervalo definido, com a opção de gerar eventos recorrentes.
  * System.Threading: Fornece um mecanismo para executar um método em uma thread de pool de threads em intervalos especificos
  * 
  */
    class ClasseTimer
    {
        static void Main(string[] _)
        {
            /*
             * A mais básica é a classe Time do namespace System.Threading que pode ser configurado para chamar um único delegate
             * de retorno chamado após um perído especificado. Todos os seus valores de configuração são fornecidos como 
             * parâmetros do construtor.
             * - O Delegate de retonor de chamada para o invocador
             * - O estado para passa o delegate de retorno da chamada
             * - O delay antes da primeira chamada em milissegundos 
             * - O intervalo entre as chamadas sebsequentes em milissegundos
             */
            var timer = new System.Timers.Timer(5)
            {
                AutoReset = false
            };
            timer.Elapsed += (source, eventArgs) =>
            {
                Console.WriteLine("Executando timer");
            };
            timer.Start();
            Console.ReadLine();
            /*
             * Essa classe é a mais flexível pois ao invés de invocar o callback, ela dispara um evento o qual pode ter multiplos
             * manipuladores, sem que nenhum estado poss ser passado para eles
             * - O temporizador é inicialmente desativo e o método Start deve ser chamado para habilitá-lo
             * - Podemos parar o temporizador usando o método Stop e reiniciá-lo chamando o método Start novamente.
             * - Em vez de chamar esses dois métodos, a propriedade Enabled pode ser configurado com o valor apropriado
             * - A propriedade AutoReset especifica se o evento Elapsed será invocado apenas uma ou várias vezes.
             */


            /*
             * A classe System.Threading é muito semalhante a System.Timers, no entando, seu evento tem um nome e assinatura
             * diferentes, e não existe a propriedade AutoStart. Isso só torna impossível configurar esse timer para ser 
             * chamado apenas uma vez. Para conseguir isso, o método Stop deve ser chamado no manipulador de eventos.
             * 
             */
            System.Threading.TimerCallback callback = new System.Threading.TimerCallback(Tick);
            Console.WriteLine("Criando um timer : {0}\n",
                               DateTime.Now.ToString("h:mm:ss"));
            // cria o segundo timer
            System.Threading.Timer stateTimer = new System.Threading.Timer(callback, null, 0, 1000);
            // laço infinito
            for (; ; )
            {
                // adiciona um delay para 100 milisegundos 
                System.Threading.Thread.Sleep(100);
            }

        }

        static public void Tick(Object stateInfo)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
        }

        static public void DesarmTheBomb()
        {
            int i = 0;
            System.Timers.Timer timer = new System.Timers.Timer(1000);

            i--;
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("                  DESARME A BOMBA");
            Console.WriteLine("");
            Console.WriteLine("                Tempo Restante:  " + i.ToString());
            Console.WriteLine("");
            Console.WriteLine("=================================================");
            if (i == 0)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("==============================================");
                Console.WriteLine("         B O O O O O M M M M M ! ! ! !");
                Console.WriteLine("");
                Console.WriteLine("               G A M E  O V E R");
                Console.WriteLine("==============================================");
                timer.Close();
                timer.Dispose();
            }
            GC.Collect();
        }
    }
}
