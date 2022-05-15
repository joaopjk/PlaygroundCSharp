using Adpter.Domain;
using System;
using System.Collections.Generic;

namespace Adpter
{
    public class SistemaMensalidades
    {
        public void CalcularMensalidade(List<Aluno> listaAlunos)
        {
            foreach (Aluno aluno in listaAlunos)
            {
                var mensalidade = aluno.Mensalidade * 1.1M;

                Console.WriteLine($"Aluno: {aluno.Nome} - Valor Mensalidade R$ {mensalidade}");
            }
        }
    }
}
