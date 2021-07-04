using System;
using System.Collections.Generic;

namespace Comparator
{/*
  * Para classificar uma lista de objetos, podemos usar o método Sort() que executa a classficação local. A classificação 
  * pode ser feita usando um delegate Comparison<T> ou através de uma implementação IComparer<T>.
  */
    class Program
    {
        static void Main(string[] args)
        {

            Aluno joao = new Aluno("João Cícero Vicente Sousa", 26);
            Aluno alessandro = new Aluno("Alessandro Henrique Oliveira", 32);
            Aluno vitoria = new Aluno("Victoria Campos Ribeiro", 21);
            Aluno francina = new Aluno("Francini Iara Sousa", 30);
            Aluno jucemie = new Aluno("Jucemie Sousa Santos", 60);

            List<Aluno> alunos = new List<Aluno>() { joao, alessandro, vitoria, francina, jucemie };

            alunos.Sort(delegate (Aluno x, Aluno y)
            {
                return x.Idade.CompareTo(y.Idade);
            });

            alunos.Sort((x, y) => x.Idade.CompareTo(y.Idade));

            Console.WriteLine(String.Join(Environment.NewLine, alunos));
            Console.ReadLine();
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
