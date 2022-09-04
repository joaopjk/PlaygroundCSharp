using System;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{/*
  * O método Enumerable.Range gera uma sequência de números dentro de um intervalo especificado. Para isso eçe usa o método 
  * estático Range() da classe Enumerable dentro do System.Linq
  * Retorno : IEnumerable<int>
  * Sintaxe: Enumerable.Range (int start, int count);
  */
    static class Enumerables
    {
        static void Main(string[] _)
        {
            foreach (var numero in Enumerable.Range(5, 50))
                Console.Write(numero + " ");

            Console.WriteLine();

            //Gerando uma sequência na ordem reversa e descendente
            foreach (var numero in Enumerable.Range(1, 10).Reverse())
                Console.Write(numero + " ");

            //Gerando uma sequência de números pares/ímpares
            var pares = Enumerable.Range(0, 10).Select(n => n * 2);

            //Certo número de elementos selecionados apenas os que correspondem ao critério( pares ou impares)
            pares = Enumerable.Range(1, 20).Where(n => n % 2 == 0);
            var impares = Enumerable.Range(1, 20).Where(n => n % 2 == 1);

            //Trabalhando com decimais
            var decimais = Enumerable.Range(10, 10).Select(n => n / 10f);

            //Trabalhando com strings
            var fonts = Enumerable.Range(1, 10).Select(n => (n * 10) + "pt").ToArray();

            //Usando Range para gerar múltiplos objetos complexos
            Task[] tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                //tasks[i] = TaskFactory.StartNew("código");
            }

            //tasks = Enumerable.Range(1, 20)
            //    .Select(i => TaskFactory.StartNew("código"))
            //    .ToArray();

            Console.ReadKey();
        }
    }
}
