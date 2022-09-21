using System;
using System.Collections.Generic;

namespace Composite.Exercicio
{
  //Composite
  public class Grupo : ItemQuestionario
  {
    private readonly IList<ItemQuestionario> _itens = new List<ItemQuestionario>();
    public Grupo(string descricao) : base(descricao) { }

    public override void Exibir()
    {
      Console.WriteLine($"Grupo: {Descricao}");
      foreach (var item in _itens)
      {
        item.Exibir();
      }
    }
    public void Add(ItemQuestionario item)
    {
      _itens.Add(item);
    }
    public void Remove(ItemQuestionario item)
    {
      _itens.Remove(item);
    }
  }
}
