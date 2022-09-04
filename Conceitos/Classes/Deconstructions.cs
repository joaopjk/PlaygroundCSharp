using System;

namespace Classes
{
  static class Deconstructions
  {
    static void Main(string[] _)
    {
      var aluno = new Aluno("João Cícero Vicente", "Sousa");
      var (nome, sobrenome) = aluno;

      Console.WriteLine(nome + "" + sobrenome);
    }
  }

  public class Aluno
  {
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Aluno(string nome, string sobrenome)
    {
      Nome = nome;
      Sobrenome = sobrenome;
    }

    public void Deconstruct(out string nome, out string sobrenome)
    {
      nome = Nome;
      sobrenome = Sobrenome;
    }
  }

  public static class DeconstructionExtension
  {
    public static void Deconsctruct(this Aluno obj, out object nome, out object sobrenome)
    {
      nome = obj.Nome;
      sobrenome = obj.Sobrenome;
    }
  }
}
