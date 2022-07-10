using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            List<string> listaAulas = new()
            {
                aulaIntro,
                aulaModelando,
                aulaSets
            };
            listaAulas.ForEach(x => Console.WriteLine(x));
            //List<string> listaAulas = new();
            //listaAulas.Add(aulaIntro);
            //listaAulas.Add(aulaModelando);
            //listaAulas.Add(aulaSets);
            //listaAulas.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("A primeira aula é: " + listaAulas.First());
            Console.WriteLine("A última aula é: " + listaAulas.Last());
            listaAulas[0] = "Trabalhando com Listas";
            listaAulas.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("A primeira aula 'Trabalhando' é: " + listaAulas.First(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A útilma aula 'Trabalhando' é: " + listaAulas.Last(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A primeira aula 'Modelando' é: " + listaAulas.FirstOrDefault(aula => aula.Contains("Modelando")));
            listaAulas.Reverse();
            listaAulas.ForEach(x => Console.WriteLine(x));
            listaAulas.Reverse();
            listaAulas.ForEach(x => Console.WriteLine(x));
            listaAulas.RemoveAt(listaAulas.Count - 1);
            listaAulas.ForEach(x => Console.WriteLine(x));
            listaAulas.Add("Conclusão");
            listaAulas.ForEach(x => Console.WriteLine(x));
            listaAulas.Sort();
            listaAulas.ForEach(x => Console.WriteLine(x));
            List<string> listaCopia = listaAulas.GetRange(listaAulas.Count - 2, 2);
            listaCopia.ForEach(x => Console.WriteLine(x));
            List<string> listaClone = new(listaAulas);
            listaClone.ForEach(x => Console.WriteLine(x));
            listaClone.RemoveRange(listaClone.Count - 2, 2);
            listaClone.ForEach(x => Console.WriteLine(x));
            List<Aula> listaObjetos = new()
            {
                new Aula(aulaIntro,20),
                new Aula(aulaModelando,18),
                new Aula(aulaSets,16)
            };
            listaObjetos.ForEach(x => Console.WriteLine(x.ToString()));
            listaObjetos.Sort();
            listaObjetos.ForEach(x => Console.WriteLine(x.ToString()));
            listaObjetos.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
            listaObjetos.ForEach(x => Console.WriteLine(x.ToString()));
            Curso cSharpColecoes = new("C# Collections", "João Cícero Vicente");
            cSharpColecoes.AddAula(new Aula(aulaIntro, 20));
            cSharpColecoes.AddAula(new Aula(aulaModelando, 18));
            cSharpColecoes.AddAula(new Aula(aulaSets, 25));
            cSharpColecoes.GetAulas()?.ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine(cSharpColecoes.ToString());
            cSharpColecoes.OrdenarAulaPorTempo();
            cSharpColecoes.GetAulas()?.ToList().ForEach(x => Console.WriteLine(x.ToString()));
            cSharpColecoes.OrdenarAulaPorTema();
            cSharpColecoes.GetAulas()?.ToList().ForEach(x => Console.WriteLine(x.ToString()));
            cSharpColecoes.TotalizandoTempoAulas();
            #endregion
            #region Sets

            #endregion
        }
        #region Classes
        private class Aula : IComparable<Aula>
        {
            public string Titulo { get; set; }
            public int Tempo { get; set; }
            public Aula(string titulo, int tempo)
            {
                Titulo = titulo;
                Tempo = tempo;
            }

            public override string ToString()
            {
                return $"Aula: {this.Titulo} | Tempo/minutos: {this.Tempo}";
            }

            public int CompareTo(Aula other)
            {
                return this.Titulo.CompareTo(other.Titulo);
            }
        }
        private class Curso
        {
            private IList<Aula> Aulas;
            public string Nome { get; set; }
            public string Instrutor { get; set; }
            public Curso(string nome, string instrutor)
            {
                Aulas = new List<Aula>();
                Nome = nome;
                Instrutor = instrutor;
            }
            public void AddAula(Aula aula)
            {
                Aulas.Add(aula);
            }
            public void RmvAula(Aula aula)
            {
                Aulas.Remove(aula);
            }
            public void OrdenarAulaPorTempo()
            {
                this.Aulas.ToList().Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
            }
            public void OrdenarAulaPorTema()
            {
                this.Aulas.ToList().Sort((este, outro) => este.Titulo.CompareTo(outro.Titulo));
            }
            public void TotalizandoTempoAulas()
            {
                Console.WriteLine(this.Aulas.ToList()?.Sum(x => x.Tempo));
            }
            public IList<Aula> GetAulas()
            {
                return new ReadOnlyCollection<Aula>(Aulas);
            }

            public override string ToString()
            {
                return $"Nome: {this.Nome} | Instrutor: {this.Instrutor}" +
                    $"Aulas:{string.Join(" |", Aulas)} ";
            }
        }
        #endregion
    }
}
