using System;

namespace ModeloAnemico
{
  static class Program
  {
    static void Main(string[] _)
    {
      Console.WriteLine("Hello World!");
    }
  }

  //class Cliente
  //{
  //    public int Id { get; set; }
  //    public string Nome { get; set; }
  //    public string Endereco { get; set; }
  //}

  public sealed class Client
  {
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Endereco { get; private set; }

    public Client(int id, string nome, string endereco)
    {
      Validar(id, nome, endereco);
      Id = id;
      Nome = nome;
      Endereco = endereco;
    }

    public void Update(int id, string nome, string endereco)
    {
      Validar(id, nome, endereco);
      Id = id;
      Nome = nome;
      Endereco = endereco;
    }

    private static void Validar(int id, string nome, string endereco)
    {
      if (id < 0)
        throw new InvalidOperationException("");
      if (string.IsNullOrEmpty(nome))
        throw new InvalidOperationException("");
      if (string.IsNullOrEmpty(endereco))
        throw new InvalidOperationException("");
    }
  }
}
