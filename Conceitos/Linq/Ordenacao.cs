using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    static class Ordenacao
    {
        static void Main(string[] _)
        {
            Aluno joao = new Aluno("João Cícero Vicente Sousa", 26);
            Aluno alessandro = new Aluno("Alessandro Henrique Oliveira", 32);
            Aluno vitoria = new Aluno("Victoria Campos Ribeiro", 21);
            Aluno francina = new Aluno("Francini Iara Sousa", 30);
            Aluno jucemie = new Aluno("Jucemie Sousa Santos", 60);

            List<Aluno> alunos = new List<Aluno>() { joao, alessandro, vitoria, francina, jucemie };

            alunos = alunos.OrderBy(x => x.Idade).ToList();

            alunos = (from e in alunos
                      orderby e.Idade
                      select e).ToList();

            var resultado = from a in alunos
                            orderby a.Nome, a.Idade
                            select new { a.Nome };

            Console.WriteLine(string.Join(Environment.NewLine, alunos));
            Console.WriteLine(string.Join(Environment.NewLine, resultado));
            Console.ReadKey();
        }
    }
    class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Aluno(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public override string ToString()
        {
            return "(" + Nome + ", " + Idade + ")";
        }
    }
}
