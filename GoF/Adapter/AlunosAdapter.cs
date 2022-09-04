using System;
using System.Collections.Generic;

namespace Adapter
{
    public class AlunosAdapter : ICalculaMensalidade
    {
        public void ProcessaCalculoMensalidade(string[,] alunosArray)
        {
            List<Aluno> alunos = new();
            ConverteArrayParaList(alunosArray, alunos);
            SistemaMensalidades.CalcularMensalidade(alunos);
        }

        private void ConverteArrayParaList(string[,] alunosArray, List<Aluno> alunos)
        {
            for (int i = 0; i < alunosArray.GetLength(0); i++)
            {
                alunos.Add(new Aluno(
                        id: Convert.ToInt32(alunosArray[i, 0]),
                        nome: alunosArray[i, 1],
                        mensalidade: Convert.ToDecimal(alunosArray[i, 3])
                    ));
            }
        }
    }
}
