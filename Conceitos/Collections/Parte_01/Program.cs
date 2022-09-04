using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Parte_01
{
  internal static class Program
  {
    static void Main(string[] _)
    {
      const string aulaIntro = "Introdução as coleçãos";
      const string aulaModelando = "Modelando a Classe Aula";
      const string aulaSets = "Trabalhando com conjuntos";
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
      aulas[^1] = "Conclusão";
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
      Console.WriteLine("A primeira aula é: " + listaAulas?.First());
      Console.WriteLine("A última aula é: " + listaAulas?.Last());
      listaAulas[0] = "Trabalhando com Listas";
      listaAulas.ForEach(x => Console.WriteLine(x));
      Console.WriteLine("A primeira aula 'Trabalhando' é: " + listaAulas.First(aula => aula.Contains("Trabalhando")));
      Console.WriteLine("A útilma aula 'Trabalhando' é: " + listaAulas.Last(aula => aula.Contains("Trabalhando")));
      Console.WriteLine("A primeira aula 'Modelando' é: " + listaAulas?.FirstOrDefault(aula => aula.Contains("Modelando")));
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
                new Aula(aulaIntro, 20),
                new Aula(aulaModelando, 18),
                new Aula(aulaSets, 16)
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
      /*
       * 1. Não permite duplicidade
       * 2. Os elementos não são mantidos em ordem específica
       */
      ISet<string> alunos = new HashSet<string>() { "Vanessa", "João", "Pedro", "Ana" };
      Console.WriteLine(string.Join(", ", alunos));
      alunos.Add("Priscila");
      alunos.Add("Fabio");
      Console.WriteLine(string.Join(", ", alunos));
      alunos.Remove("Ana");
      alunos.Add("Augusto");
      Console.WriteLine(string.Join(", ", alunos));
      Curso javaColecoes = new("Java Coleções", "João Cícero Vicente Sousa", new HashSet<Aula>());
      javaColecoes.AddAula(new Aula(aulaIntro, 20));
      javaColecoes.AddAula(new Aula(aulaModelando, 21));
      javaColecoes.AddAula(new Aula(aulaSets, 15));
      Aluno a1 = new("João", 1);
      Aluno a2 = new("Ana", 2);
      Aluno a3 = new("Vanessa", 3);
      javaColecoes.Matricula(a1, a2, a3);
      javaColecoes.GetAlunos().ToList().ForEach(x => Console.WriteLine(x.ToString()));
      Console.WriteLine($"Aluno {a1.Nome} está matrículado?");
      Console.WriteLine(javaColecoes.EstaMatricula(a1));
      Aluno a4 = new("João", 1);
      Console.WriteLine($"Aluno {a4.Nome} está matrículado?");
      Console.WriteLine(javaColecoes.EstaMatricula(a4));
      Console.WriteLine(a1.Equals(a4));
      #endregion
      #region Dicionarios
      Console.WriteLine("Aluno 1 " + javaColecoes.BuscaMatricula(1)?.ToString());
      javaColecoes.SubstituirAluno(new Aluno("Pedro de Lara", 1));
      #endregion
      #region LikedList
      /*
       * - Elementos não precisam estar em sequência em memória
       * - Cada elemento sabe quem é o anterior e o próximo
       * - Cada elemento é um nó que contém um valor
       */
      LinkedList<string> dias = new();
      var d4 = dias.AddFirst("Quarta");
      Console.WriteLine(d4.Value);
      var d2 = dias.AddBefore(d4, "Segunda");
      var d3 = dias.AddAfter(d2, "Terça");
      var d6 = dias.AddAfter(d4, "Sexta");
      var d7 = dias.AddAfter(d6, "Sábado");
      var d1 = dias.AddBefore(d2, "Domingo");
      var d5 = dias.AddBefore(d6, "Quinta");
      Console.WriteLine(String.Join(",", dias));
      Console.WriteLine(dias.Find("Quarta"));
      //dias.Remove("Quarta");
      //dias.Remove(d4);
      #endregion
      #region Stack
      var navegador = new Navegador();
      navegador.NavegarPara("google.com");
      navegador.NavegarPara("caelum.com.br");
      navegador.NavegarPara("alura.com.br");
      navegador.Anterior();
      navegador.Anterior();
      navegador.Anterior();
      navegador.Anterior();
      navegador.Proximo();
      #endregion
      #region Queue
      Queue<string> pedagio = new();
      pedagio.Enqueue("van");
      pedagio.Dequeue();
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
      private readonly IEnumerable<Aula> Aulas;
      private readonly ISet<Aluno> Alunos;
      private readonly IDictionary<int, Aluno> alunosDicionario;
      public string Nome { get; set; }
      public string Instrutor { get; set; }
      public Curso(string nome, string instrutor, IEnumerable<Aula> lista = null, ISet<Aluno> alunos = null)
      {
        Aulas = (lista != null) ? new List<Aula>() : lista;
        Nome = nome;
        Instrutor = instrutor;
        Alunos = alunos ?? new HashSet<Aluno>();
        alunosDicionario = new Dictionary<int, Aluno>();
      }
      public Curso(string nome, string instrutor)
      {
        Aulas = new List<Aula>();
        Nome = nome;
        Instrutor = instrutor;
      }
      public void AddAula(Aula aula)
      {
        Aulas.ToList().Add(aula);
      }
      public void RmvAula(Aula aula)
      {
        Aulas.ToList().Remove(aula);
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
        return new ReadOnlyCollection<Aula>(Aulas.ToList());
      }
      public void Matricula(params Aluno[] alunos)
      {
        if (alunos.Length > 0)
        {
          alunos.ToList().ForEach(x =>
          {
            this.Alunos.Add(x);
            this.alunosDicionario.Add(x.NumeroMatricula, x);
          });
        }
      }
      public void RmvMatricula(params Aluno[] alunos)
      {
        if (alunos.Length > 0)
          alunos.ToList().ForEach(x => this.Alunos.Remove(x));
      }
      public IEnumerable<Aluno> GetAlunos()
      {
        return new ReadOnlyCollection<Aluno>(Alunos.ToList());
      }
      public bool EstaMatricula(Aluno aluno)
      {
        return Alunos.Contains(aluno);
      }
      public override string ToString()
      {
        return $"Nome: {this.Nome} | Instrutor: {this.Instrutor}" +
            $"Aulas:{string.Join(" |", Aulas)} ";
      }
      public Aluno BuscaMatricula(int matricula)
      {
        alunosDicionario.TryGetValue(matricula, out Aluno aluno);
        return aluno;
      }
      public void SubstituirAluno(Aluno aluno)
      {
        if (alunosDicionario.ContainsKey(aluno.NumeroMatricula)) alunosDicionario[aluno.NumeroMatricula] = aluno;
      }
    }
    private class Aluno
    {
      public string Nome { get; set; }
      public int NumeroMatricula { get; set; }
      public Aluno(string nome, int numeroMatricula)
      {
        Nome = nome;
        NumeroMatricula = numeroMatricula;
      }

      public override string ToString()
      {
        return $"Nome: {this.Nome} | Matrícula: {this.NumeroMatricula}";
      }

      public override bool Equals(object obj)
      {
        if (obj is Aluno outro)
          return this.Nome.Equals(outro.Nome);
        return false;
      }

      public override int GetHashCode()
      {
        /*
         * Dois objetos que são iguais possuem o mesmo hash code
         * Porém, nem sempre dois objetos com o mesmo hash não são necessáriamente iguais
         */
        return this.Nome.GetHashCode();
      }
    }
    private class Navegador
    {
      private string atual = "vazia";
      private readonly Stack<string> historicoAnterior = new();
      private readonly Stack<string> historicoProximo = new();
      public Navegador()
      {
        Console.WriteLine("Página atual: " + atual);
      }
      public void NavegarPara(string url)
      {
        atual = url;
        historicoAnterior.Push(url);
        Console.WriteLine("Página atual: " + atual);
      }

      public void Anterior()
      {
        if (historicoAnterior.Count > 0)
        {
          historicoProximo.Push(atual);
          atual = historicoAnterior.Pop();
          Console.WriteLine("Página atual: " + atual);
        }
      }

      public void Proximo()
      {
        if (historicoProximo.Count > 0)
        {
          historicoAnterior.Push(atual);
          atual = historicoProximo.Pop();
          Console.WriteLine("Página atual: " + atual);
        }
      }
    }
    #endregion
  }
}
