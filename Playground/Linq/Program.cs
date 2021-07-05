using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{/*
  * É um conjunto de tecnologias baseadas na integração de funcionalidade de consulta diretamente lingugaem c#
  * - Operações chamadas diretamente a partir das coleções
  * - Consultas são objetos de primeira classe
  * - Suporte do compilador de IntelliSense da IDE
  * Possui diversar operações de consulta, cujos parâmetros tipicamente são expressões lambda ou expressões de sintaxe
  * similar à SQl
  * 
  * Passos
  * - Criar um data source(coleção, array, recurso de E/S)
  * - Definir a query
  * - Executar a query(foreach ou alguma operação de terminal)
  */
    class Program
    {
        static void Main(string[] args)
        {
            // Especificar um data source
            int[] numeros = new int[] { 1, 2, 3, 4, 5 };

            // definir a query
            var result = numeros.Where(n => n % 2 == 0)
                                .Select(n => n * 10);

            //Executar a consulta
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
