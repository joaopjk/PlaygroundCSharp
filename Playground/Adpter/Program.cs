using Adpter.Exercicio;
using System;
using System.Collections.Generic;

namespace Adpter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alunosArray = SistemaEscolar.GetListaAlunosMensalidades();
            ICalculaMensalidade calculo = new AlunosAdapter();
            calculo.ProcessaCalculaMensalidade(alunosArray);

            //Exc
            IGrafico grafico = new GraficoAdapter();
            grafico.GerarGrafico("", new List<string>(), new List<int>());
            Console.ReadKey();
        }
    }
}
