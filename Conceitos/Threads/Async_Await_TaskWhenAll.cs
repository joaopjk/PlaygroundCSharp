using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Threads
{/*
  * Usamos modificadores async na declaração de um método para indicar que o método é assíncrono e neste caso ele depende
  * da palavra-chave await. Isso ocorre porque, ao usar o await, seu programa deve "esperar" um resultado, e essa espera é 
  * feita em segundo plano de forma assíncrona, assim , o await espera até que o método retorne seu resultado, e isso ocorre
  * sem bloquear o fluxo do programa.
  * O Await examina o que está pendente para ver se já foi concluído, se o awaitable já estiver concluído, o método apenas 
  * continuará executando (de forma síncrona, como um método norma). Se o await vê que o awaitale não foi concluído,ele age
  * de forma assíncrona. Ele diz ao awaitable para executar o restande do método quado ele for concluído e, em seguida,
  * retorna do método assíncrono.
  */
    class Async_Await_TaskWhenAll
    {
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var soma = await SomaAsync();
            Console.WriteLine("Tempo decorrido após a soma terminar..." + stopwatch.Elapsed);

            var concatena = await ConcatenaAsync();
            Console.WriteLine("Tempo decorrido após soma e concatenação terminarem..." + stopwatch.Elapsed);

            Console.WriteLine($"Resultado da soma =  {soma}");
            Console.WriteLine($"Resultado da concatenação = {concatena}");

            Console.ReadKey();

            stopwatch = new Stopwatch();
            stopwatch.Start();

            var somaTask = SomaAsync();
            var concatenaTask = ConcatenaAsync();

            /*
             * Quando se executa utilizando o Task.WhenAll, os dois métodos são executados em parelo, assim utilizando
             * toda a capacidade dos métodos assíncronos.
             */
            await Task.WhenAll(somaTask, concatenaTask);

            Console.WriteLine($"Tempo decorrido após soma e concatenação terminarem : {stopwatch.Elapsed}");
            Console.WriteLine($"Resultado da soma = {somaTask.Result}");
            Console.WriteLine($"Resultado da concatenação =  {concatenaTask.Result}");

            Console.ReadKey();
        }

        private static async Task<string> ConcatenaAsync()
        {
            /*
             * A partir da geração de números inteiros em um intervalo, retorna uma strin que é a concatenação
             * dos caracteres ASC que representam esses números.
             */
            string palavra = string.Empty;

            foreach (var contador in Enumerable.Range(65, 26))
            {
                palavra = string.Concat(palavra, (char)contador);
                await Task.Delay(150);
            }

            return palavra;
        }

        private static async Task<int> SomaAsync()
        {
            /*
             * A partir da geração de números inteiros em um intervalo, soma esses números e retornar a soma
             */
            int soma = 0;

            foreach (var contador in Enumerable.Range(0, 25))
            {
                soma += contador;
                await Task.Delay(100);
            }

            return soma;
        }
    }
}
