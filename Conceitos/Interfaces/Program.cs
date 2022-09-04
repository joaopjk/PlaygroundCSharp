using System;

namespace Interfaces
{/*
  * As interfaces podem ser implícita ou explícitas.
  * Nas implementações implícitas( o padrão), os membros da interface são publicas na classe, e, nas explícitas, os membros
  * da interface não são declarados como membros públicos na classe e não podem ser acessados diretamente usando uma instância
  * da classe. Isso somente será possível fazer a conversar foraçadas(cast) dos membros.
  */
  static class Program
  {
    static void Main(string[] _)
    {
      var demoTeste = new DemoExplicita();

      //Usando cast
      ((ITeste)demoTeste).ExibirAviso();

      //Usando o operador is
      if (demoTeste is ITeste d)
        d.ExibirAviso();

      //Usando o operado as
      (demoTeste as ITeste)?.ExibirAviso();

      //Invocando o método como parâmetro de um método
      Exemplo(demoTeste);

      Console.ReadKey();
    }

    interface ITeste
    {
      void ExibirAviso();
    }

    class DemoImplicita : ITeste
    {
      public void ExibirAviso() => Console.WriteLine("Interface Implícita");
    }

    class DemoExplicita : ITeste
    {
      void ITeste.ExibirAviso() => Console.WriteLine("Interface Implícita");
    }

    static void Exemplo(ITeste teste)
    {
      teste.ExibirAviso();
    }

    interface IForma
    {
      void Desenhar();
    }
    interface IFigura
    {
      void Desenhar();
    }

    class Controle : IForma, IFigura
    {
      void IFigura.Desenhar()
      {
        Console.WriteLine("Desenhar Figura");
      }

      void IForma.Desenhar()
      {
        Console.WriteLine("Desenhar Figura");
      }
    }
  }
}
