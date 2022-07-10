using System;
using System.Collections.Generic;
using System.Linq;

namespace Parte_01
{
    internal class Program
    {
        static void Main(string[] _)
        {
            string aulaIntro = "Introdução as coleçãos";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";
            #region Matriz
            //string[] aulas = { aulaIntro, aulaModelando, aulaSets };
            //string[] aulas = new string[]{ aulaIntro, aulaModelando, aulaSets };
            //string[] aulas = new string[3] {aulaIntro,aulaModelando,aulaSets};
            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;
            foreach (string s in aulas) Console.WriteLine(s);
            Console.WriteLine("Aula modelando está no índice: " + Array.IndexOf(aulas, aulaModelando));
            Console.WriteLine("Aula modelando está no índice: " + Array.LastIndexOf(aulas, aulaModelando));
            Array.Reverse(aulas); // Invertendo a ordens do array
            foreach (string s in aulas) Console.WriteLine(s);
            Array.Resize(ref aulas, 2); // Reajustar o tamanho do array
            foreach (string s in aulas) Console.WriteLine(s);
            Array.Resize(ref aulas, 3);
            aulas[aulas.Length - 1] = "Conclusão";
            foreach (string s in aulas) Console.WriteLine(s);
            Array.Sort(aulas);//Ordena o array em ordem alfabética
            string[] copia = new string[2];
            Array.Copy(aulas, 1, copia, 0, 2);//Copiando arrays
            foreach (string s in copia) Console.WriteLine(s);
            string[] clone = aulas.Clone() as string[];
            foreach (string s in clone) Console.WriteLine(s);
            Array.Clear(clone, 1, 2);
            foreach (string s in clone) Console.WriteLine(s);
            #endregion
            #region Listas
            Console.Clear();
            //List<string> listaAulas = new()
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};
            //listaAulas.ForEach(x => Console.WriteLine(x));
            List<string> listaAulas = new();
            listaAulas.Add(aulaIntro);
            listaAulas.Add(aulaModelando);
            listaAulas.Add(aulaSets);
            listaAulas.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("A primeira aula é: " + listaAulas.First());
            Console.WriteLine("A última aula é: " + listaAulas.Last());
            #endregion
        }
    }
}
