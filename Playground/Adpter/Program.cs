using System;

namespace Adpter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alunosArray = SistemaEscolar.GetListaAlunosMensalidades();
            ICalculaMensalidade calculo = new AlunosAdapter();
            calculo.ProcessaCalculaMensalidade(alunosArray);

            Console.ReadKey();
        }
    }
}
