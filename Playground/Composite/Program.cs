using Composite.Exercicio;
using System;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Organizacao organizacao = new() { Nome = "João Inc" };

            Organizacao departamentoTI = new() { Nome = "TI" };
            departamentoTI.Add(new Funcionario { Nome = "João", Horas = 44 });
            departamentoTI.Add(new Funcionario { Nome = "Pedro", Horas = 44 });
            departamentoTI.Add(new Funcionario { Nome = "Annie", Horas = 44 });

            Organizacao departamentoRH = new() { Nome = "RH" };
            departamentoRH.Add(new Funcionario { Nome = "Paulo", Horas = 44 });
            departamentoRH.Add(new Funcionario { Nome = "Andre", Horas = 44 });
            departamentoRH.Add(new Funcionario { Nome = "Marlom", Horas = 44 });

            organizacao.Add(departamentoTI);
            organizacao.Add(departamentoRH);

            organizacao.GetHoraTrabalhada();


            var grupoA = new Grupo("A) Portguês");
            var questao1 = new Questao("Quando usamos a crase ?");
            var questao2 = new Questao("Explique cada uso do porque.");
            var questao3 = new Questao("Qual o plural de anis ?");
            grupoA.Add(questao1);
            grupoA.Add(questao2);
            grupoA.Add(questao3);

            var grupoRaiz = new Grupo("Questionario");
            grupoRaiz.Add(grupoA);

            grupoRaiz.Exibir();
            Console.ReadKey();
        }
    }
}
