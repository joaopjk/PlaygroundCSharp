﻿using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] _)
        {
            var alunosArray = SistemaEscolar.GeListaAlunosMensalidades();
            AlunosAdapter alunosAdpter = new();
            alunosAdpter.ProcessaCalculoMensalidade(alunosArray);

            Console.ReadKey();
        }
    }
}
